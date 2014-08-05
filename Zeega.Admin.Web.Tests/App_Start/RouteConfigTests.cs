using System.Web.Routing;
using NUnit.Framework;
using Zed.Web.Test;

namespace Zeega.Admin.Web.Tests.App_Start {
    [TestFixture]
    public class RouteConfigTests {

        #region Fields and Properties

        private RouteCollection routes;

        #endregion

        #region Setups

        [TestFixtureSetUp]
        public void FixtureSetup() {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        }

        #endregion

        #region GameProvider routes

        [Test]
        public void GameProviderRouteMatch() {
            // Arrange
            const string gameProviderIndexUrl = "~/game/providers";
            const string gameProviderDetailsUrl = "~/game/provider/123/spil-games";
            const string gameProviderEditUrl = "~/game/provider/edit/123/spil-games";
            const string gameProviderCreateUrl = "~/game/provider/create";

            // Assert
            Assert.IsTrue(RouteTest.RouteMatch(gameProviderIndexUrl, routes, "Index", "GameProvider"));
            Assert.IsTrue(RouteTest.RouteMatch(gameProviderDetailsUrl, routes, "Details", "GameProvider", new { id = 123}));
            Assert.IsTrue(RouteTest.RouteMatch(gameProviderEditUrl, routes, "Edit", "GameProvider", new { id = 123 }));
            Assert.IsTrue(RouteTest.RouteMatch(gameProviderCreateUrl, routes, "Create", "GameProvider"));

        }

        [Test]
        public void GameProviderRouteNotMatch() {
            // Arrange
            const string gameProviderDetailsUrl = "~/game/provider/id-with-alpha/spil-games";

            // Assert
            Assert.IsTrue(RouteTest.RouteNotMatch(gameProviderDetailsUrl, routes));

        }

        #endregion

    }
}
