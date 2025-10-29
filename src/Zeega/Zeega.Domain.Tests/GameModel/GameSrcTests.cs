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
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(gameSrc.Width, Is.EqualTo(WIDTH));
                Assert.That(gameSrc.Height, Is.EqualTo(HEIGHT));
                Assert.That(gameSrc.SrcUri, Is.EqualTo(SRC_URI));
                Assert.That(gameSrc.SrcType, Is.EqualTo(GameSrcType.Swf));
                Assert.That(gameSrc.IsSrcOnline, Is.True);
            });

        }

        [Test]
        public void Height_InvalidHeight_ExceptionTrown() {
            // Arrange
            const int WIDTH = -12;
            const int HEIGHT = 480;
            const string SRC_URI = @"http://example.com/game/game.swf";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new GameSrc(WIDTH, HEIGHT, SRC_URI, GameSrcType.Swf));
        }

        [Test]
        public void Width_InvalidWidth_ExceptionTrown() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = -12;
            const string SRC_URI = @"http://example.com/game/game.swf";

            // Act
            Assert.Throws<ArgumentException>(() => new GameSrc(WIDTH, HEIGHT, SRC_URI, GameSrcType.Swf));
        }

    }
}
