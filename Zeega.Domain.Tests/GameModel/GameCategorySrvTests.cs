using System.Collections.Generic;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameCategorySrvTests {

        [Test]
        public void OrderGameCategories_ListOfGameCategories_SequencePropertySetInAccordanceToOrderingInList() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var gameCat1 = new GameCategory(appTenant, "Action");
            var gameCat2 = new GameCategory(appTenant, "Sports");
            var gameCat3 = new GameCategory(appTenant, "Adventure");
            var gameCat4 = new GameCategory(appTenant, "Puzzles");
            var gameCategories = new List<GameCategory>() { gameCat1, gameCat2, gameCat3, gameCat4 };

            // Act
            GameCategorySrv.OrderGameCategories(gameCategories);

            // Assert
            Assert.AreEqual(1, gameCat1.Sequence);
            Assert.AreEqual(2, gameCat2.Sequence);
            Assert.AreEqual(3, gameCat3.Sequence);
            Assert.AreEqual(4, gameCat4.Sequence);
        }
    }
}
