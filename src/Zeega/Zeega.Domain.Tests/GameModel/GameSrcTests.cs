using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameSrcTests {

        [Test]
        public void CreateGameSrcWithUrl_WithParams_GameSrcCreated() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string SRC_URL = @"http://example.com/game/game.swf";

            // Act
            var gameSrc = GameSrc.CreateGameSrcWithUrl(WIDTH, HEIGHT, GameSrcType.Swf, SRC_URL);

            // Asssert
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(gameSrc.Width, Is.EqualTo(WIDTH));
                Assert.That(gameSrc.Height, Is.EqualTo(HEIGHT));
                Assert.That(gameSrc.SrcUrl, Is.EqualTo(SRC_URL));
                Assert.That(gameSrc.EmbedCode, Is.Null);
                Assert.That(gameSrc.SrcLocalFile, Is.Null);
                Assert.That(gameSrc.SrcType, Is.EqualTo(GameSrcType.Swf));
                Assert.That(gameSrc.IsSrcOnline, Is.True);
                Assert.That(gameSrc.IsEmbedded, Is.False);
            });

        }

        [Test]
        public void CreateGameSrcWithEmbedCode_WithParams_GameSrcCreated() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string EMBED_CODE = "embed_code";

            // Act
            var gameSrc = GameSrc.CreateGameSrcWithEmbedCode(WIDTH, HEIGHT, GameSrcType.Swf, EMBED_CODE);

            // Asssert
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(gameSrc.Width, Is.EqualTo(WIDTH));
                Assert.That(gameSrc.Height, Is.EqualTo(HEIGHT));
                Assert.That(gameSrc.EmbedCode, Is.EqualTo(EMBED_CODE));
                Assert.That(gameSrc.SrcUrl, Is.Null);
                Assert.That(gameSrc.SrcLocalFile, Is.Null);
                Assert.That(gameSrc.SrcType, Is.EqualTo(GameSrcType.Swf));
                Assert.That(gameSrc.IsSrcOnline, Is.True);
                Assert.That(gameSrc.IsEmbedded, Is.True);
            });

        }

        [Test]
        public void CreateGameSrcWithLocalFile_WithParams_GameSrcCreated() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string LOCAL_FILE = "local_file.swf";

            // Act
            var gameSrc = GameSrc.CreateGameSrcWithLocalFile(WIDTH, HEIGHT, GameSrcType.Swf, LOCAL_FILE);

            // Asssert
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(gameSrc.Width, Is.EqualTo(WIDTH));
                Assert.That(gameSrc.Height, Is.EqualTo(HEIGHT));
                Assert.That(gameSrc.SrcLocalFile, Is.EqualTo(LOCAL_FILE));
                Assert.That(gameSrc.SrcUrl, Is.Null);
                Assert.That(gameSrc.EmbedCode, Is.Null);
                Assert.That(gameSrc.SrcType, Is.EqualTo(GameSrcType.Swf));
                Assert.That(gameSrc.IsSrcOnline, Is.True);
                Assert.That(gameSrc.IsEmbedded, Is.False);
            });

        }

        [Test]
        public void GetSrcUri_WhenBothLocalAndOfflineUrlExists_SrcLocalFileUri() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string LOCAL_FILE = "local_file.swf";
            const string SRC_URL = @"http://example.com/game/game.swf";

            var gameSrc = GameSrc.CreateGameSrcWithLocalFile(WIDTH, HEIGHT, GameSrcType.Swf, LOCAL_FILE, SRC_URL);
            gameSrc.IsSrcOnline = false;

            // Act
            var resultUri = gameSrc.GetSrcUri();

            // Asssert
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(resultUri, Is.EqualTo(LOCAL_FILE));
                Assert.That(gameSrc.SrcLocalFile, Is.EqualTo(resultUri));
                Assert.That(gameSrc.IsSrcOnline, Is.False);
                Assert.That(gameSrc.IsEmbedded, Is.False);
            });


        }

        [Test]
        public void GetSrcUri_WhenBothLocalAndOnlineUrlExists_SrcUrlUri() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string LOCAL_FILE = "local_file.swf";
            const string SRC_URL = @"http://example.com/game/game.swf";

            var gameSrc = GameSrc.CreateGameSrcWithLocalFile(WIDTH, HEIGHT, GameSrcType.Swf, LOCAL_FILE, SRC_URL);

            // Act
            var resultUri = gameSrc.GetSrcUri();

            // Asssert
            Assert.Multiple(() => {
                Assert.That(gameSrc, Is.Not.Null);
                Assert.That(resultUri, Is.EqualTo(SRC_URL));
                Assert.That(gameSrc.SrcUrl, Is.EqualTo(resultUri));
                Assert.That(gameSrc.IsSrcOnline, Is.True);
                Assert.That(gameSrc.IsEmbedded, Is.False);
            });

        }



        [Ignore("No restriction of width and height")]
        [Test]
        public void Height_InvalidHeight_ExceptionTrown() {
            // Arrange
            const int WIDTH = -12;
            const int HEIGHT = 480;
            const string SRC_URL = @"http://example.com/game/game.swf";

            // Act
            TestDelegate testDelegate = () => {
                var gameSrc = GameSrc.CreateGameSrcWithUrl(WIDTH, HEIGHT, GameSrcType.Swf, SRC_URL);
            };

            // Assert
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Ignore("No restriction of width and height")]
        [Test]
        public void Width_InvalidWidth_ExceptionTrown() {
            // Arrange
            const int WIDTH = 640;
            const int HEIGHT = -12;
            const string SRC_URL = @"http://example.com/game/game.swf";

            // Act
            TestDelegate testDelegate = () => {
                var gameSrc = GameSrc.CreateGameSrcWithUrl(WIDTH, HEIGHT, GameSrcType.Swf, SRC_URL);
            };

            // Assert
            Assert.Throws<ArgumentException>(testDelegate);
        }

    }
}
