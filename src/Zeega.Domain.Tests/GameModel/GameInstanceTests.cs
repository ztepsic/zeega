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
            Assert.That(gameName, Is.EqualTo(gameInstance.Name));
            Assert.That(gameInstance.Slug, Is.EqualTo("angry-birds"));

        }

        [Test]
        public void SetShortDescription_InvalidNumberOfChars_ExceptionTrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            var gameInstance = new GameInstance(appTenant, new Game("Angry brids", new GameProvider("Spil Games")));
            const string shortDescription = @"Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.
                Second installment of Freedom Tower - The Invasion with 6 new worlds, 
                different weapons, allied troops, powerful bosses and much more. Our planet faces danger once more.";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gameInstance.ShortDescription = shortDescription);

        }

        [Test]
        public void AddTag_NewTagWithDifferentLanguageCodeAsOfAppTenant_ArgumentExceptionThrown() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            var appTenant = new AppTenant("ZeegaHR", new LanguageCode("hr"));
            var tag = Tag.CreateTag("Nogomet", new LanguageCode("es"), baseTag);
            var game = new Game("Angry birds", new GameProvider("Spil Games"));
            var gameInstance = new GameInstance(appTenant, game, "Ptice");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gameInstance.AddTag(tag));
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
            Assert.Multiple(() => {
                Assert.That(gameInstance.Tags, Has.Count.EqualTo(2));
                Assert.That(isTagRemoved, Is.True);
                Assert.That(gameInstance.Tags, Does.Not.Contain(tag2));
            });

        }

        [Test]
        public void SetPrimaryCategory_PrimaryCategoryWithDifferentAppTenant_ArgumentExceptionThrwen() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant1, "Primary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds", new GameProvider("Spil Games")));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gameInstance.PrimaryInstanceCategory = primaryCategory);

        }

        [Test]
        public void AddSecondaryCategory_SecondaryCategoryWithDifferentAppTenant_ArgumentExceptionThrwen() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var secondaryCategory = new GameInstanceCategory(appTenant1, "Secondary Category");

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant2, "Primary Category");
            var gameInstance = new GameInstance(appTenant2, new Game("Angry Birds", new GameProvider("Spil Games"))) {
                PrimaryInstanceCategory = primaryCategory
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => gameInstance.AddSecondaryCategory(secondaryCategory));
        }

        [Test]
        public void AddSecondaryCategory_SecondaryCategoryWhichAlreadyExistInList_ArgumentExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var primaryCategory = new GameInstanceCategory(appTenant, "Primary Category");
            var secondaryCategory = new GameInstanceCategory(appTenant, "Secondary Category");

            var gameInstance = new GameInstance(appTenant, new Game("Angry Birds", new GameProvider("Spil Games"))) {
                PrimaryInstanceCategory = primaryCategory
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => {
                gameInstance.AddSecondaryCategory(secondaryCategory);
                gameInstance.AddSecondaryCategory(secondaryCategory);
            });
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
            Assert.Multiple(() => {
                Assert.That(gameInstance.SecondaryCategories, Has.Count.EqualTo(2));
                Assert.That(isCategoryRemoved, Is.True);
                Assert.That(gameInstance.SecondaryCategories.Contains(gameCategory2), Is.False);
            });

        }

    }
}
