using System;
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
            var appTenant = new AppTenant("Zeega", "en");
            const string gameName = "Angry birds";

            // Act
            var game = new Game(appTenant, gameName);

            // Assert
            Assert.AreEqual(gameName, game.Name);
            Assert.AreEqual("angry-birds", game.Slug);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetShortDescription_InvalidNumberOfChars_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", "en");
            var game = new Game(appTenant, "Angry brids");
            const string shortDescription = @"Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.
                Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.";

            // Act
            game.ShortDescription = shortDescription;

            // Assert
        }

        [Test]
        public void AddTag_NewTag_NewTagAddedToTagList() {
            // Arrange
            var tag = new Tag("Tower defence");
            var appTenant = new AppTenant("Zeega", "en");
            var game = new Game(appTenant, "Angry birds");

            // Act
            game.AddTag(tag);

            // Assert
            Assert.AreEqual(1, game.Tags.Count());
            Assert.AreEqual(tag, game.Tags[0]);
        }

        [Test]
        public void RemoveTag_TagToBeRemoved_RemovedTagFromTagList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", "en");
            var game = new Game(appTenant, "Angry birds");
            var tag1 = new Tag("Tower defence");
            var tag2 = new Tag("Multiplayer");
            var tag3 = new Tag("strategy");
            game.AddTag(tag1);
            game.AddTag(tag2);
            game.AddTag(tag3);

            // Act
            var isTagRemoved = game.RemoveTag(tag2);
            
            // Assert
            Assert.AreEqual(2, game.Tags.Count());
            Assert.IsTrue(isTagRemoved);
            Assert.IsFalse(game.Tags.Contains(tag2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Height_InvalidHeight_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", "en");

            // Act
            var game = new Game(appTenant, "Angry birds");

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Width_InvalidWidth_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", "en");

            // Act
            var game = new Game(appTenant, "Angry birds");

            // Assert
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Create_ExistingGameInstance_NewGameInstanceWithCopiedValuesFromPassedGameArgument() {
            // Arrange

            // Act

            // Assert
        }

        #endregion
    }
}
