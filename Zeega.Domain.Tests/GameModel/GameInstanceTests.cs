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
            var game = new Game(gameName, new GameProvider("Spil Games"));

            // Act
            var gameInstance = new GameInstance(appTenant, game, gameName);

            // Assert
            Assert.AreEqual(gameName, gameInstance.Name);
            Assert.AreEqual("angry-birds", gameInstance.Slug);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetShortDescription_InvalidNumberOfChars_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            var gameInstance = new GameInstance(appTenant, new Game("Angry brids", new GameProvider("Spil Games")));
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
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var gameInstance = new GameInstance(appTenant, game, "Ptice");

            // Act
            gameInstance.AddTag(tag);

            // Assert
        }

        [Test]
        public void RemoveTag_TagToBeRemoved_RemovedTagFromTagList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var gameInstance = new GameInstance(appTenant, game);
            var tag1 = Tag.CreateBaseTag("Tower defense");
            var tag2 = Tag.CreateBaseTag("Multiplayer");
            var tag3 = Tag.CreateBaseTag("strategy");
            gameInstance.AddTag(tag1)
                    .AddTag(tag2)
                    .AddTag(tag3);

            // Act
            var isTagRemoved = gameInstance.RemoveTag(tag2);

            // Assert
            Assert.AreEqual(2, gameInstance.Tags.Count);
            Assert.IsTrue(isTagRemoved);
            Assert.IsFalse(gameInstance.Tags.Contains(tag2));
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void SetPrimaryCategory_PrimaryCategoryWithDifferentAppTenant_ArgumentExceptionThrwen() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant1, "Primary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds", new GameProvider("Spil Games")));

            // Act
            gameInstance.PrimaryInstanceCategory = primaryCategory;

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSecondaryCategory_SecondaryCategoryWithDifferentAppTenant_ArgumentExceptionThrwen() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var secondaryCategory = new GameInstanceCategory(appTenant1, "Secondary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant2, "Primary Category");
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds", new GameProvider("Spil Games"))) {
                PrimaryInstanceCategory = primaryCategory
            };

            // Act
            gameInstance.AddSecondaryCategory(secondaryCategory);

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSecondaryCategory_SecondaryCategoryWhichAlreadyExistInList_ArgumentExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant, "Primary Category");
            var secondaryCategory = new GameInstanceCategory(appTenant, "Secondary Category");

            var gameInstance = new GameInstance(appTenant, new Game("Angry Birds", new GameProvider("Spil Games"))) {
                PrimaryInstanceCategory = primaryCategory
            };

            // Act
            gameInstance.AddSecondaryCategory(secondaryCategory);
            gameInstance.AddSecondaryCategory(secondaryCategory);

            // Assert
        }

        [Test]
        public void RemoveSecondaryCategory_CategoryToBeRemoved_RemovedCategoryFromSecondaryCategoryList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var gameInstance = new GameInstance(appTenant, game) {
                PrimaryInstanceCategory = new GameInstanceCategory(appTenant, "primaryInstanceCategory")
            };
            var gameCategory1 = new GameInstanceCategory(appTenant, "Category1");
            var gameCategory2 = new GameInstanceCategory(appTenant, "Category2");
            var gameCategory3 = new GameInstanceCategory(appTenant, "Category3");

            gameInstance.AddSecondaryCategory(gameCategory1)
                .AddSecondaryCategory(gameCategory2)
                .AddSecondaryCategory(gameCategory3);
            

            // Act
            var isCategoryRemoved = gameInstance.RemoveSecondaryCategory(gameCategory2);

            // Assert
            Assert.AreEqual(2, gameInstance.SecondaryCategories.Count);
            Assert.IsTrue(isCategoryRemoved);
            Assert.IsFalse(gameInstance.SecondaryCategories.Contains(gameCategory2));
        }

    }
}
