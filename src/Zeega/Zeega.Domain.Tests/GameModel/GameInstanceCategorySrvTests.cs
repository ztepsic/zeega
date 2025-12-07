using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameInstanceCategorySrvTests {

        [Test]
        public void OrderGameCategories_ListOfGameCategories_SequencePropertySetInAccordanceToOrderingInList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var gameCat1 = new GameInstanceCategory(appTenant, "Action");
            var gameCat2 = new GameInstanceCategory(appTenant, "Sports");
            var gameCat3 = new GameInstanceCategory(appTenant, "Adventure");
            var gameCat4 = new GameInstanceCategory(appTenant, "Puzzles");
            var gameCategories = new List<GameInstanceCategory>() { gameCat1, gameCat2, gameCat3, gameCat4 };

            // Act
            GameInstanceCategorySrv.OrderGameCategories(gameCategories);

            // Assert
            Assert.Multiple(() => {
                Assert.That(gameCat1.Sequence, Is.EqualTo(1));
                Assert.That(gameCat2.Sequence, Is.EqualTo(2));
                Assert.That(gameCat3.Sequence, Is.EqualTo(3));
                Assert.That(gameCat4.Sequence, Is.EqualTo(4));
            });
        }
    }
}
