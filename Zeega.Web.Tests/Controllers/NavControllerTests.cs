using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Web.Controllers;
using Zeega.Web.Models.Nav;

namespace Zeega.Web.Tests.Controllers {
    [TestFixture]
    public class NavControllerTests {

        [Test]
        public void Nav_ReturnsCategories() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE), true);
            IAppConfig appConfig = new AppConfig(appTenant);

            // create mock repository
            Mock<IGameInstanceCategoriesRepository> gameCategoriesRepoMock = new Mock<IGameInstanceCategoriesRepository>();
            gameCategoriesRepoMock.Setup(m => m.GetCategoriesWithGames(appTenant)).Returns(new GameInstanceCategory[] {
                new GameInstanceCategory(appTenant, "Sports"),
                new GameInstanceCategory(appTenant, "Action & Arcade"),
                new GameInstanceCategory(appTenant, "Strategy"),
                new GameInstanceCategory(appTenant, "Adventure"),
            });

            NavController navController = new NavController(appConfig, gameCategoriesRepoMock.Object);

            // Act
            MainNavViewModel mainNavViewModel = ((MainNavViewModel) navController.MainNav().Model);
            var gameCategories = mainNavViewModel.GameCategories.ToArray();
            // Assert
            Assert.AreEqual(4, gameCategories.Length);
        }

    }
}
