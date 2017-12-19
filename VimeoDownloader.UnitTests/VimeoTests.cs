using System;
using System.Threading.Tasks;
using Xunit;

namespace VimeoDownloader.UnitTests
{
    public class VimeoTests
    {
        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetVideoWithLowQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId, VideoQuality.Low);

            //assert
            Assert.NotEqual(0, video.Data.Length);
            Assert.NotEqual(string.Empty, video.FileName);
        }

        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetVideoWithDefaultQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId);

            //assert
            Assert.NotEqual(0, video.Data.Length);
            Assert.NotEqual(string.Empty, video.FileName);
        }

        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetVideoWithHighQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId, VideoQuality.High);

            //assert
            Assert.NotEqual(0, video.Data.Length);
            Assert.NotEqual(string.Empty, video.FileName);
        }

    }
}
