using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameInstanceTests {

        [Test]
        public void Ctor_WithParams_CreatesGameInstance() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            const string gameName = "Angry birds";
            var game = new Game(gameName);

            // Act
            var gameInstance = new GameInstance(appTenant, game, gameName);

            // Assert
            Assert.AreEqual(gameName, gameInstance.Name);
            Assert.AreEqual("angry-birds", gameInstance.Slug);

        }

        [Test]
        public void Ctor_WithParams_CreatesGameInstanceWithPopulatedFieldsBasedOnGameData() {
            
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetShortDescription_InvalidNumberOfChars_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            var gameInstance = new GameInstance(appTenant, new Game("Angry brids"));
            const string shortDescription = @"Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.
                Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.";

            // Act
            gameInstance.ShortDescription = shortDescription;

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTag_NewTagWithDifferentLanguageCodeAsOfAppTenant_ArgumentExceptionThrown() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            var appTenant = new AppTenant("ZeegaHR", new LanguageCode("hr"));
            var tag = Tag.CreateTag("Nogomet", new LanguageCode("es"), baseTag);
            var game = new Game("Angry birds");
            var gameInstance = new GameInstance(appTenant, game, "Ptice");

            // Act
            gameInstance.AddTag(tag);

            // Assert
        }

        [Test]
        public void RemoveTag_TagToBeRemoved_RemovedTagFromTagList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            var game = new Game("Angry birds");
            var gameInstance = new GameInstance(appTenant, game);
            var tag1 = Tag.CreateBaseTag("Tower defense");
            var tag2 = Tag.CreateBaseTag("Multiplayer");
            var tag3 = Tag.CreateBaseTag("strategy");
            gameInstance.AddTag(tag1);
            gameInstance.AddTag(tag2);
            gameInstance.AddTag(tag3);

            // Act
            var isTagRemoved = gameInstance.RemoveTag(tag2);

            // Assert
            Assert.AreEqual(2, gameInstance.Tags.Count);
            Assert.IsTrue(isTagRemoved);
            Assert.IsFalse(gameInstance.Tags.Contains(tag2));
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void AddSecondaryCategory_TODO_ArgumentExceptionThrown() {
            
        }

        [Test]
        public void RemoveSecondaryCategory_CategoryToBeRemoved_RemovedCategoryFromTagList() {
            
        }

    }
}
