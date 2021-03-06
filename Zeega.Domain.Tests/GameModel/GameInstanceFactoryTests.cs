﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameInstanceFactoryTests {

        [Test]
        public void CreateCloneOf_ExistingGameInstance_NewGameInstanceWithCopiedValuesFromPassedGameArgument() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = new Game("Angry Birds", new GameProvider("Spil Games"));
            var gameInstance1 = new GameInstance(appTenant1, game) {
                PrimaryInstanceCategory = new GameInstanceCategory(appTenant1, "Sports1")
            };
            var baseTag1 = Tag.CreateBaseTag("TagEN1");
            var baseTag2 = Tag.CreateBaseTag("TagEN2");
            gameInstance1
                .AddTag(baseTag1)
                .AddTag(baseTag2);

            var secondaryCategory1_1 = new GameInstanceCategory(appTenant1, "Action1_1");
            var secondaryCategory1_2 = new GameInstanceCategory(appTenant1, "Action1_2");
            gameInstance1.AddSecondaryCategory(secondaryCategory1_1)
                .AddSecondaryCategory(secondaryCategory1_2);

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            const string gameInstance2Name = "Angry Birds New Instance";

            var tag1 = Tag.CreateTag("TagHR1", appTenant2.LanguageCode, baseTag1);
            var tag2 = Tag.CreateTag("TagHR2", appTenant2.LanguageCode, baseTag2);

            var tagsRepoMock = new Mock<ITagsRepository>();
            tagsRepoMock.Setup(tagsRepo => tagsRepo.GetTagsFor(gameInstance1.Tags, appTenant2.LanguageCode))
                .Returns(new List<Tag> { tag1, tag2 });

            var primaryCategory2 = new GameInstanceCategory(appTenant2, "Sports2");
            var secondaryCategory2_1 = new GameInstanceCategory(appTenant2, "Action2_1");
            var secondaryCategory2_2 = new GameInstanceCategory(appTenant2, "Action2_2");

            var gameCategoryMappingRepoMock = new Mock<IGameCategoryMappingsRepository>();
            gameCategoryMappingRepoMock.Setup(gameCatMapRepo => gameCatMapRepo.GetMappedGameCategoryFrom(gameInstance1.PrimaryInstanceCategory))
                .Returns(primaryCategory2);

            gameCategoryMappingRepoMock.Setup(gameCatMapRepo => gameCatMapRepo.GetMappedGameCategoriesFrom(gameInstance1.SecondaryCategories))
                .Returns(new List<GameInstanceCategory> { secondaryCategory2_1, secondaryCategory2_2});

            var gameInstanceFactory = new GameInstanceFactory(tagsRepoMock.Object, gameCategoryMappingRepoMock.Object);

            // Act
            var gameInstance2 = gameInstanceFactory.CreateCloneOf(gameInstance1, appTenant2, gameInstance2Name);

            // Assert
            Assert.IsNotNull(gameInstance2);
            Assert.AreNotSame(gameInstance1, gameInstance2);
            Assert.AreNotEqual(gameInstance1, gameInstance2);
            Assert.AreEqual(appTenant2, gameInstance2.AppTenant);
            Assert.AreEqual(gameInstance2Name, gameInstance2.Name);
            Assert.AreEqual(gameInstance1.Description, gameInstance2.Description);
            Assert.AreEqual(gameInstance1.ShortDescription, gameInstance2.ShortDescription);
            Assert.AreEqual(gameInstance1.Instructions, gameInstance2.Instructions);
            Assert.AreEqual(gameInstance1.Controls, gameInstance2.Controls);
            Assert.IsTrue(gameInstance2.Tags.Count == 2);
            Assert.AreEqual(tag1, gameInstance2.Tags[0]);
            Assert.AreEqual(tag2, gameInstance2.Tags[1]);
            Assert.IsNotNull(gameInstance2.PrimaryInstanceCategory);
            Assert.AreEqual(primaryCategory2, gameInstance2.PrimaryInstanceCategory);
            Assert.IsTrue(gameInstance2.SecondaryCategories.Count == 2);
            Assert.AreEqual(secondaryCategory2_1, gameInstance2.SecondaryCategories[0]);
            Assert.AreEqual(secondaryCategory2_2, gameInstance2.SecondaryCategories[1]);

        }

        [Test]
        public void CreateWithGamePropertyCopy_WithParams_CreatesGameInstanceWithPopulatedFieldsBasedOnGameData() {
            // Arrange
            var gameProvider = new GameProvider("Spil Games");
            var game = new Game("Angry Birds", gameProvider) {
                Description = "Description",
                ShortDescription = "ShortDescription",
                Instructions = "Instruction"
            };

            var baseTag1 = Tag.CreateBaseTag("TagEN1");
            var baseTag2 = Tag.CreateBaseTag("TagEN2");
            game.AddTag(baseTag1)
                .AddTag(baseTag2);

            //var secondaryCategory1_1 = new GameInstanceCategory(appTenant1, "Action1_1");
            //var secondaryCategory1_2 = new GameInstanceCategory(appTenant1, "Action1_2");
            //game.AddSecondaryCategory(secondaryCategory1_1)
            //    .AddSecondaryCategory(secondaryCategory1_2);

            var appTenant = new AppTenant("Otkrij Igre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));

            var tag1 = Tag.CreateTag("TagHR1", appTenant.LanguageCode, baseTag1);
            var tag2 = Tag.CreateTag("TagHR2", appTenant.LanguageCode, baseTag2);

            var tagsRepoMock = new Mock<ITagsRepository>();
            tagsRepoMock.Setup(tagsRepo => tagsRepo.GetTagsFor(game.Tags, appTenant.LanguageCode))
                .Returns(new List<Tag> { tag1, tag2 });

            //var primaryCategory2 = new GameInstanceCategory(appTenant2, "Sports2");
            //var secondaryCategory2_1 = new GameInstanceCategory(appTenant2, "Action2_1");
            //var secondaryCategory2_2 = new GameInstanceCategory(appTenant2, "Action2_2");

            var gameCategoryMappingRepoMock = new Mock<IGameCategoryMappingsRepository>();
            //gameCategoryMappingRepoMock.Setup(gameCatMapRepo => gameCatMapRepo.GetMappedGameCategoryFrom(gameInstance1.primaryInstanceCategory))
            //    .Returns(primaryCategory2);

            //gameCategoryMappingRepoMock.Setup(gameCatMapRepo => gameCatMapRepo.GetMappedGameCategoriesFrom(gameInstance1.SecondaryCategories))
            //    .Returns(new List<GameInstanceCategory> { secondaryCategory2_1, secondaryCategory2_2 });


            var gameInstanceFactory = new GameInstanceFactory(tagsRepoMock.Object, gameCategoryMappingRepoMock.Object);


            // Act
            var gameInstance = gameInstanceFactory.CreateWithGamePropertyCopy(appTenant, game);

            // Assert
            Assert.AreEqual(gameInstance.Name, gameInstance.Name);
            Assert.AreEqual(gameInstance.Description, gameInstance.Description);
            Assert.AreEqual(gameInstance.ShortDescription, gameInstance.ShortDescription);
            Assert.AreEqual(gameInstance.Instructions, gameInstance.Instructions);
            Assert.IsTrue(gameInstance.Tags.Count == 2);
            Assert.AreEqual(tag1, gameInstance.Tags[0]);
            Assert.AreEqual(tag2, gameInstance.Tags[1]);
        }

    }
}
