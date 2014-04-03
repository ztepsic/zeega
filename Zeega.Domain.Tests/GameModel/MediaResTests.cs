using System;
using System.IO;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class MediaResTests {

        [Test]
        public void Ctor_WithParams_CreatesMediaRes() {
            // Arrange
            const string THUMB_SRC_URI = "http://example.com/assets/1/thumb.jpg";
            const string SRC_URI = "http://example.com/assets/1/screenshot.jpg";


            // Act
            var mediaResource = new MediaRes(SRC_URI, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Screenshot) {
                ThumbSrcUri = THUMB_SRC_URI,
                ThumbSrcWidth = MediaRes.MIN_WIDTH,
                ThumbSrcHeight = MediaRes.MIN_HEIGHT,
            };

            // Assert
            Assert.IsNotNull(mediaResource);
            Assert.AreEqual(THUMB_SRC_URI, mediaResource.ThumbSrcUri);
            Assert.AreEqual(MediaRes.MIN_WIDTH, mediaResource.ThumbSrcWidth);
            Assert.AreEqual(MediaRes.MIN_HEIGHT, mediaResource.ThumbSrcHeight);
            Assert.AreEqual(SRC_URI, mediaResource.SrcUri);
            Assert.AreEqual(MediaRes.MIN_WIDTH, mediaResource.SrcWidth);
            Assert.AreEqual(MediaRes.MIN_HEIGHT, mediaResource.SrcHeight);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThumbSrcUri_WithSamePathAsSrc_ThrownExceptionOnlyIfTypeIsVideo() {
            // Arrange
            const string SRC_URI = "http://example.com/assets/1/screenshot.jpg";
            const string THUMB_SRC_URI = SRC_URI;

            var mediaResource = new MediaRes(SRC_URI, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Video);

            // Act
            mediaResource.ThumbSrcUri = THUMB_SRC_URI;

            // Assert

        }

    }
}
