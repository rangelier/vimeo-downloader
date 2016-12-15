using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VimeoDownloader.Models;

namespace VimeoDownloader
{
    /// <summary>
    /// Class Vimeo.
    /// </summary>
    public static class Vimeo
    {
        /// <summary>
        /// This method can be used to download a Vimeo video.
        /// The video with medium quality will be downloaded by default.
        /// </summary>
        /// <param name="videoId">The video identifier.</param>
        /// <returns>Task&lt;VideoData&gt;.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="VimeoException"></exception>
        public static async Task<Video> Download(string videoId)
        {
            if (string.IsNullOrWhiteSpace(videoId))
                throw new ArgumentNullException(nameof(videoId));

            return await Download(videoId, VideoQuality.Medium);
        }
        /// <summary>
        /// This method can be used to download a Vimeo video.
        /// The video with the specified quality will be downloaded (if possible).
        /// </summary>
        /// <param name="videoId">The video identifier.</param>
        /// <param name="videoQuality">The video quality.</param>
        /// <returns>Task&lt;Video&gt;.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="VimeoDownloader.VimeoException"></exception>
        /// <exception cref="VimeoException"></exception>
        public static async Task<Video> Download(string videoId, VideoQuality videoQuality)
        {
            if (string.IsNullOrWhiteSpace(videoId))
                throw new ArgumentNullException(nameof(videoId));

            Video video = null;

            try
            {
                Configuration configuration = await GetConfiguration(videoId);
                byte[] data = await DownloadByteArray(configuration, videoQuality);

                video = Video.Factory.Create(data, configuration, videoQuality);
            }
            catch (Exception innerException)
            {
                throw new VimeoException(videoId, innerException);
            }

            return await Task.FromResult<Video>(video);
        }
        /// <summary>
        /// This utility method get's the corresponding configuration for this video.
        /// </summary>
        /// <param name="videoID">The video identifier.</param>
        /// <returns>Task&lt;Configuration&gt;.</returns>
        private static async Task<Configuration> GetConfiguration(string videoID)
        {
            string configUrl = $"https://player.vimeo.com/video/{videoID}/config";

            Configuration configuration;

            using (var client = new HttpClient())
            {
                string result = await client.GetStringAsync(configUrl);
                configuration = JsonConvert.DeserializeObject<Configuration>(result);
            }

            return await Task.FromResult<Configuration>(configuration);
        }
        /// <summary>
        /// This utility method downloads the video as an byte array.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="videoQuality">The video quality.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="VimeoDownloader.VimeoException"></exception>
        private static async Task<byte[]> DownloadByteArray(Configuration configuration, VideoQuality videoQuality)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            byte[] data;

            using (var client = new HttpClient())
            {
                Progressive progressive = configuration.GetProgressive(videoQuality);

                if (progressive == null)
                    throw new VimeoException($"The requested video is not available in this quality {videoQuality}");

                data = await client.GetByteArrayAsync(progressive.Url);
            }

            return await Task.FromResult<byte[]>(data);
        }
    }
}
