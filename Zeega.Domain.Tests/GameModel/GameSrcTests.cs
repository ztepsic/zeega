using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameSrcTests {

        [Test]
        public void Ctor_WithParams_GameSrcCreated() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string SRC_URI = @"http://example.com/game/game.swf";

            // Act
            var gameSrc = new GameSrc(WIDTH, HEIGHT, SRC_URI, GameSrcType.Swf);

            // Asssert
            Assert.IsNotNull(gameSrc);
            Assert.AreEqual(WIDTH, gameSrc.Width);
            Assert.AreEqual(HEIGHT, gameSrc.Height);
            Assert.AreEqual(SRC_URI, gameSrc.SrcUri);
            Assert.AreEqual(GameSrcType.Swf, gameSrc.SrcType);
            Assert.IsTrue(gameSrc.IsSrcOnline);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Height_InvalidHeight_ExceptionTrown() {
            // Arrange
            const int WIDTH = -12;
            const int HEIGHT = 480;
            const string SRC_URI = @"http://example.com/game/game.swf";

            // Act
            var gameSrc = new GameSrc(WIDTH, HEIGHT, SRC_URI, GameSrcType.Swf);

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Width_InvalidWidth_ExceptionTrown() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = -12;
            const string SRC_URI = @"http://example.com/game/game.swf";

            // Act
            var gameSrc = new GameSrc(WIDTH, HEIGHT, SRC_URI, GameSrcType.Swf);

            // Assert

            // Assert
        }

    }
}
