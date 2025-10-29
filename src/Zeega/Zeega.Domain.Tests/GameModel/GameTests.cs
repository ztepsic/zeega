using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameTests {

        #region Tests

        [Test]
        public void Ctor_WithParams_CreatesGame() {
            // Arrange
            const string gameName = "Angry birds";

            // Act
            var game = new Game(gameName, new GameProvider("Spil Games"));

            // Assert
            Assert.That(game.Name, Is.EqualTo(gameName));

        }

        [Test]
        public void SetGameSrc_GameSrc_GameSrcAssignedToGame() {
            // Arrange
            var game = new Game("Angry Birds", new GameProvider("Spil Games"));
            var gameSrc = new GameSrc(640, 480, @"http://example.com/game/game.swf", GameSrcType.Swf);

            // Act
            game.GameSrc = gameSrc;


            // Assert
            Assert.That(game.GameSrc, Is.EqualTo(gameSrc));
        }

        [Test]
        public void CreateMediaRes_WithParams_MediaResourceCreatedAndAddedToGameSrc() {
            // Arrange
            var game = new Game("Angry Birds", new GameProvider("Spil Games"));
            const string MEDIA_RES_SRC_URI = @"http://example.com/assets/scrrenshot.jpg";
            const string THUMB_MEDIA_RES_SRC_URI = @"http://example.com/assets/thumb.jpg";

            // Act
            var mediaRes = game.CreateMediaResource(MEDIA_RES_SRC_URI, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Screenshot);
            mediaRes.ThumbSrcUri = THUMB_MEDIA_RES_SRC_URI;
            mediaRes.ThumbSrcWidth = MediaRes.MIN_WIDTH;
            mediaRes.ThumbSrcHeight = MediaRes.MIN_HEIGHT;

            // Assert
            Assert.Multiple(() => {
                Assert.That(mediaRes, Is.Not.Null);
                Assert.That(game.MediaResources, Has.Count.EqualTo(1));
                Assert.That(game.MediaResources, Does.Contain(mediaRes));
                Assert.That(mediaRes.ThumbSrcWidth, Is.EqualTo(MediaRes.MIN_WIDTH));
                Assert.That(mediaRes.ThumbSrcHeight, Is.EqualTo(MediaRes.MIN_HEIGHT));
                Assert.That(mediaRes.SrcUri, Is.EqualTo(MEDIA_RES_SRC_URI));
                Assert.That(mediaRes.ThumbSrcUri, Is.EqualTo(THUMB_MEDIA_RES_SRC_URI));
                Assert.That(mediaRes.SrcWidth, Is.EqualTo(MediaRes.MIN_WIDTH));
                Assert.That(mediaRes.SrcHeight, Is.EqualTo(MediaRes.MIN_HEIGHT));
                Assert.That(mediaRes.OrderSequence, Is.EqualTo(1));
            });

        }

        [Test]
        public void DeleteMediaRes_MediaRes_MediaResourceDeletedFromGameSrc() {
            // Arrange
            var game = new Game("Angry Birds", new GameProvider("Spil Games"));
            const string MEDIA_RES_SRC_URI_1 = @"http://example.com/assets/scrrenshot.jpg";
            const string MEDIA_RES_SRC_URI_2 = @"http://example.com/assets/scrrenshot2.jpg";
            const string MEDIA_RES_SRC_URI_3 = @"http://example.com/assets/scrrenshot3.jpg";

            var mediaRes1 = game.CreateMediaResource(MEDIA_RES_SRC_URI_1, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Screenshot);
            var mediaRes2 = game.CreateMediaResource(MEDIA_RES_SRC_URI_2, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Screenshot);
            var mediaRes3 = game.CreateMediaResource(MEDIA_RES_SRC_URI_3, MediaRes.MIN_WIDTH, MediaRes.MIN_HEIGHT, MediaResType.Screenshot);

            // Act
            var isRemoved = game.RemoveMediaResource(mediaRes2);


            // Assert
            Assert.Multiple(() => {
                Assert.That(isRemoved, Is.True);
                Assert.That(game.MediaResources, Does.Contain(mediaRes1));
                Assert.That(game.MediaResources, Does.Not.Contain(mediaRes2));
                Assert.That(game.MediaResources, Does.Contain(mediaRes3));
                Assert.That(mediaRes1.OrderSequence, Is.EqualTo(1));
                Assert.That(mediaRes3.OrderSequence, Is.EqualTo(2));
            });


        }

        [Test]
        public void RemoveTag_TagToBeRemoved_RemovedTagFromTagList() {
            // Arrange
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var tag1 = Tag.CreateBaseTag("Tower defense");
            var tag2 = Tag.CreateBaseTag("Multiplayer");
            var tag3 = Tag.CreateBaseTag("strategy");
            game.AddTag(tag1)
                .AddTag(tag2)
                .AddTag(tag3);

            // Act
            var isTagRemoved = game.RemoveTag(tag2);

            // Assert
            Assert.Multiple(() => {
                Assert.That(game.Tags.Count, Is.EqualTo(2));
                Assert.That(isTagRemoved, Is.True);
                Assert.That(game.Tags, Does.Not.Contain(tag2));
            });
        }

        [Test]
        public void RemoveCategory_CategoryToBeRemoved_RemovedCategoryFromCategoryList() {
            // Arrange
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var category1 = new GameCategory("Sports");
            var category2 = new GameCategory("Action");
            game.AddCategory(category1)
                .AddCategory(category2);

            // Act
            var isCategoryRemoved = game.RemoveCategory(category2);

            // Assert
            Assert.Multiple(() => {
                Assert.That(game.Categories, Has.Count.EqualTo(1));
                Assert.That(isCategoryRemoved, Is.True);
                Assert.That(game.Categories, Does.Not.Contain(category2));
            });
        }

        #endregion
    }
}
