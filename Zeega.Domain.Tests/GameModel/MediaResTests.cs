using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class MediaResTests {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThumbSrcUri_WithSamePathAsSrc_ThrownExceptionOnlyIfTypeIsVideo() {
            // Arrange
            var game = new Game("Angry Birds");
            const string SRC_URI = "http://example.com/assets/1/screenshot.jpg";
            const string THUMB_SRC_URI = SRC_URI;

            var mediaResource = game.CreateMediaResource(SRC_URI, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Video);

            // Act
            mediaResource.ThumbSrcUri = THUMB_SRC_URI;

            // Assert

        }

    }
}
