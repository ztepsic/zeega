using System.Linq;
using NUnit.Framework;
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
            Assert.AreEqual(gameName, game.Name);

        }

        [Test]
        public void SetGameSrc_GameSrc_GameSrcAssignedToGame() {
            // Arrange
            var game = new Game("Angry Birds", new GameProvider("Spil Games"));
            var gameSrc = new GameSrc(640, 480, @"http://example.com/game/game.swf", GameSrcType.Swf);

            // Act
            game.GameSrc = gameSrc;


            // Asssert
            Assert.AreEqual(gameSrc, game.GameSrc);
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

            // Asssert
            Assert.IsNotNull(mediaRes);
            Assert.AreEqual(1, game.MediaResources.Count);
            Assert.Contains(mediaRes, game.MediaResources.ToList());
            Assert.AreEqual(MediaRes.MIN_WIDTH, mediaRes.ThumbSrcWidth);
            Assert.AreEqual(MediaRes.MIN_HEIGHT, mediaRes.ThumbSrcHeight);
            Assert.AreEqual(MEDIA_RES_SRC_URI, mediaRes.SrcUri);
            Assert.AreEqual(THUMB_MEDIA_RES_SRC_URI, mediaRes.ThumbSrcUri);
            Assert.AreEqual(MediaRes.MIN_WIDTH, mediaRes.SrcWidth);
            Assert.AreEqual(MediaRes.MIN_HEIGHT, mediaRes.SrcHeight);
            Assert.AreEqual(1, mediaRes.Sequence);

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
            

            // Asssert
            Assert.IsTrue(isRemoved);
            Assert.Contains(mediaRes1, game.MediaResources.ToList());
            Assert.IsFalse(game.MediaResources.Contains(mediaRes2));
            Assert.Contains(mediaRes3, game.MediaResources.ToList());
            Assert.AreEqual(1, mediaRes1.Sequence);
            Assert.AreEqual(2, mediaRes3.Sequence);
            
            
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
            Assert.AreEqual(2, game.Tags.Count);
            Assert.IsTrue(isTagRemoved);
            Assert.IsFalse(game.Tags.Contains(tag2));
        }

        #endregion
    }
}
