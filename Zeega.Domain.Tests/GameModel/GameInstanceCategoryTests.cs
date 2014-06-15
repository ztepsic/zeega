using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameInstanceCategoryTests {

        [Test]
        public void Ctr_WithParams_CreatesGameCategoryInstance() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameInstanceCategory gameInstanceCategory = new GameInstanceCategory(appTenant, gameName);

            // Assert
            Assert.AreEqual(gameName, gameInstanceCategory.Name);
            Assert.AreEqual(gameSlug, gameInstanceCategory.Slug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Slug_NullString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            string gameName = "Adventure & RPG";
            string gameSlug = null;

            // Act
            GameInstanceCategory gameInstanceCategory = new GameInstanceCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Slug_WhiteSpaceString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = "     ";

            // Act
            GameInstanceCategory gameInstanceCategory = new GameInstanceCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Slug_EmptyString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = string.Empty;

            // Act
            GameInstanceCategory gameInstanceCategory = new GameInstanceCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        public void Slug_StringValue_InSlugForm() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameInstanceCategory gameInstanceCategory = new GameInstanceCategory(appTenant, gameName, gameName);

            // Assert
            Assert.AreEqual(gameName, gameInstanceCategory.Name);
            Assert.AreEqual(gameSlug, gameInstanceCategory.Slug);
        }


    }
}
