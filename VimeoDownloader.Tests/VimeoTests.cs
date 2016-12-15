using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.IO;

namespace VimeoDownloader.Tests
{
    /// <summary>
    /// Class VimeoTests.
    /// </summary>
    [TestClass]
    public class VimeoTests
    {
        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task GetVideoWithLowQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId, VideoQuality.Low);

            //assert
            Assert.AreNotEqual(0, video.Data.Length);
            Assert.AreNotEqual(string.Empty, video.FileName);
        }
        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task GetVideoWithDefaultQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId);

            //assert
            Assert.AreNotEqual(0, video.Data.Length);
            Assert.AreNotEqual(string.Empty, video.FileName);
        }
        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task GetVideoWithHighQuality()
        {
            //arrange
            string videoId = "193970500";

            //act
            Video video = await Vimeo.Download(videoId, VideoQuality.High);

            //assert
            Assert.AreNotEqual(0, video.Data.Length);
            Assert.AreNotEqual(string.Empty, video.FileName);
        }
    }
}
