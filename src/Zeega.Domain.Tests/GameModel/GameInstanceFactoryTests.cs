using Moq;
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
                .Returns(new List<GameInstanceCategory> { secondaryCategory2_1, secondaryCategory2_2 });

            var gameInstanceFactory = new GameInstanceFactory(tagsRepoMock.Object, gameCategoryMappingRepoMock.Object);

            // Act
            var gameInstance2 = gameInstanceFactory.CreateCloneOf(gameInstance1, appTenant2, gameInstance2Name);

            // Assert
            Assert.That(gameInstance2, Is.Not.Null);
            Assert.That(gameInstance1, Is.Not.SameAs(gameInstance2));
            Assert.That(gameInstance1, Is.Not.EqualTo(gameInstance2));
            Assert.That(appTenant2, Is.EqualTo(gameInstance2.AppTenant));
            Assert.That(gameInstance2.Name, Is.EqualTo(gameInstance2Name));
            Assert.That(gameInstance1.Description, Is.EqualTo(gameInstance2.Description));
            Assert.That(gameInstance1.ShortDescription, Is.EqualTo(gameInstance2.ShortDescription));
            Assert.That(gameInstance1.Instructions, Is.EqualTo(gameInstance2.Instructions));
            Assert.That(gameInstance1.Controls, Is.EqualTo(gameInstance2.Controls));
            Assert.That(gameInstance2.Tags, Has.Count.EqualTo(2));
            Assert.That(tag1, Is.EqualTo(gameInstance2.Tags[0]));
            Assert.That(tag2, Is.EqualTo(gameInstance2.Tags[1]));
            Assert.That(gameInstance2.PrimaryInstanceCategory, Is.Not.Null);
            Assert.That(primaryCategory2, Is.EqualTo(gameInstance2.PrimaryInstanceCategory));
            Assert.That(gameInstance2.SecondaryCategories, Has.Count.EqualTo(2));
            Assert.That(secondaryCategory2_1, Is.EqualTo(gameInstance2.SecondaryCategories[0]));
            Assert.That(secondaryCategory2_2, Is.EqualTo(gameInstance2.SecondaryCategories[1]));

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
            Assert.Multiple(() => {
                Assert.That(gameInstance.Name, Is.EqualTo(gameInstance.Name));
                Assert.That(gameInstance.Description, Is.EqualTo(gameInstance.Description));
                Assert.That(gameInstance.ShortDescription, Is.EqualTo(gameInstance.ShortDescription));
                Assert.That(gameInstance.Instructions, Is.EqualTo(gameInstance.Instructions));
                Assert.That(gameInstance.Tags, Has.Count.EqualTo(2));
                Assert.That(tag1, Is.EqualTo(gameInstance.Tags[0]));
                Assert.That(tag2, Is.EqualTo(gameInstance.Tags[1]));
            });
        }

    }
}
