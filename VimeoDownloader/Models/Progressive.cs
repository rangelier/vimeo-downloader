namespace VimeoDownloader.Models
{
    /// <summary>
    /// Class Progressive.
    /// </summary>
    public class Progressive
    {
        /// <summary>
        /// Gets or sets the MIME.
        /// </summary>
        /// <value>The MIME.</value>
        public string Mime { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public string Quality { get; set; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }
    }
}
