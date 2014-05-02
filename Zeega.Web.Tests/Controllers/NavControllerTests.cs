using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Web.Controllers;

namespace Zeega.Web.Tests.Controllers {
    [TestFixture]
    public class NavControllerTests {

        [Test]
        public void Nav_ReturnsCategories() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE), true);

            // create mock repository
            Mock<IGameCategoriesRepository> gameCategoriesRepoMock = new Mock<IGameCategoriesRepository>();
            gameCategoriesRepoMock.Setup(m => m.GetAll()).Returns(new GameCategory[] {
                new GameCategory(appTenant, "Sports"),
                new GameCategory(appTenant, "Action & Arcade"),
                new GameCategory(appTenant, "Strategy"),
                new GameCategory(appTenant, "Adventure"),
            });

            NavController navController = new NavController(gameCategoriesRepoMock.Object);

            // Act
            GameCategory[] mainNav = ((IEnumerable<GameCategory>) navController.Main().Model).ToArray();

            // Assert
            Assert.AreEqual(4, mainNav.Length);
        }

    }
}
