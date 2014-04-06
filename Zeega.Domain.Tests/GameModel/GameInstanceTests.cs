﻿using System;
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
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = new Game("Angry Birds") {
                Description = "Description",
                ShortDescription = "ShortDescription",
                Instructions = "Instruction"
            };


            // Act
            var gameInstance = new GameInstance(appTenant, game);

            // Assert
            Assert.AreEqual(game.Name, gameInstance.Name);
            Assert.AreEqual(game.Description, gameInstance.Description);
            Assert.AreEqual(game.ShortDescription, gameInstance.ShortDescription);
            Assert.AreEqual(game.Instructions, gameInstance.Instructions);
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
            var primaryCategory = new GameCategory(appTenant1, "Primary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds"));

            // Act
            gameInstance.PrimaryCategory = primaryCategory;

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSecondaryCategory_SecondaryCategoryWithDifferentAppTenant_ArgumentExceptionThrwen() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var secondaryCategory = new GameCategory(appTenant1, "Secondary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var primaryCategory = new GameCategory(appTenant2, "Primary Category");
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds")) {
                PrimaryCategory = primaryCategory
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
            var primaryCategory = new GameCategory(appTenant, "Primary Category");
            var secondaryCategory = new GameCategory(appTenant, "Secondary Category");

            var gameInstance = new GameInstance(appTenant, new Game("Angry Birds")) {
                PrimaryCategory = primaryCategory
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
            var game = new Game("Angry birds");
            var gameInstance = new GameInstance(appTenant, game) {
                PrimaryCategory = new GameCategory(appTenant, "PrimaryCategory")
            };
            var gameCategory1 = new GameCategory(appTenant, "Category1");
            var gameCategory2 = new GameCategory(appTenant, "Category2");
            var gameCategory3 = new GameCategory(appTenant, "Category3");

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

        [Test]
        public void Create_ExistingGameInstance_NewGameInstanceWithCopiedValuesFromPassedGameArgument() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = new Game("Angry Birds");
            var gameInstance1 = new GameInstance(appTenant, game);

            // Act
            var gameInstance2 = GameInstance.Create(gameInstance1);

            // Assert
            Assert.IsNotNull(gameInstance2);
            Assert.AreNotSame(gameInstance1, gameInstance2);
            Assert.AreNotEqual(gameInstance1, gameInstance2);
            Assert.AreEqual(gameInstance1.Name, gameInstance2.Name);
        }

    }
}
