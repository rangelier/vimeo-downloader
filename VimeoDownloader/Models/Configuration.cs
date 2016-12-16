using System.Linq;

namespace VimeoDownloader.Models
{
    /// <summary>
    /// Class Configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The low quality
        /// </summary>
        private static string[] lowQuality = new string[] { "270p", "360p" };
        /// <summary>
        /// The medium quality
        /// </summary>
        private static string[] mediumQuality = new string[] { "540p", "720p" };
        /// <summary>
        /// The high quality
        /// </summary>
        private static string[] highQuality = new string[] { "1080p" };

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public Request Request { get; set; }
        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>The video.</value>
        public VideoInfo Video { get; set; }

        /// <summary>
        /// Gets the progressive.
        /// </summary>
        /// <param name="videoQuality">The video quality.</param>
        /// <returns>Progressive.</returns>
        internal Progressive GetProgressive(VideoQuality videoQuality)
        {
            //sort the video collection by quality (height).
            Request.Files.Sort();

            Progressive progressive = null;

            switch (videoQuality)
            {
                case VideoQuality.Low:
                    progressive = Request.Files.Progressive.FirstOrDefault(c => lowQuality.Contains(c.Quality));
                    break;
                case VideoQuality.Medium:
                    progressive = Request.Files.Progressive.FirstOrDefault(c => mediumQuality.Contains(c.Quality));
                    break;
                case VideoQuality.High:
                    progressive = Request.Files.Progressive.FirstOrDefault(c => highQuality.Contains(c.Quality));
                    break;
            }

            return progressive;
        }
    }
}
