using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoDownloader.Models;

namespace VimeoDownloader
{
    /// <summary>
    /// Class Video.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Video"/> class from being created.
        /// </summary>
        private Video() { }
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public byte[] Data { get; private set; }
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }
        /// <summary>
        /// Gets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public string Quality { get; private set; }

        /// <summary>
        /// Class Factory.
        /// </summary>
        internal static class Factory
        {
            /// <summary>
            /// Creates the specified data.
            /// </summary>
            /// <param name="data">The data.</param>
            /// <param name="configuration">The configuration.</param>
            /// <param name="videoQuality">The video quality.</param>
            /// <returns>Video.</returns>
            public static Video Create(byte[] data, Configuration configuration, VideoQuality videoQuality)
            {
                var video = new Video();

                var progressive = configuration.GetProgressive(videoQuality);
                string extension = Path.GetExtension(progressive.Url).Split('?')[0];

                video.Data = data;
                video.FileName = string.Concat(configuration.Video.Title, extension);
                video.Quality = progressive.Quality;

                return video;
            }
        }
    }
}
