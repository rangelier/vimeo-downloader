using System;

namespace VimeoDownloader
{
    /// <summary>
    /// Class VimeoDownloadException.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class VimeoException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public VimeoException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoException"/> class.
        /// </summary>
        /// <param name="videoId">The video identifier.</param>
        /// <param name="innerException">The inner exception.</param>
        public VimeoException(string videoId, Exception innerException)
            : base($"We are unable to download the Vimeo video {videoId}. Please check the inner exception for more details.", innerException) { }
    }
}
