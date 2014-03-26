using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameCategoryTests {

        [Test]
        public void Ctr_WithParams_CreatesGameCategoryInstance() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameCategory gameCategory = new GameCategory(appTenant, gameName);

            // Assert
            Assert.AreEqual(gameName, gameCategory.Name);
            Assert.AreEqual(gameSlug, gameCategory.Slug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_NullString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            string gameName = "Adventure & RPG";
            string gameSlug = null;

            // Act
            GameCategory gameCategory = new GameCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_WhiteSpaceString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = "     ";

            // Act
            GameCategory gameCategory = new GameCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_EmptyString_ExceptionThrown() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = string.Empty;

            // Act
            GameCategory gameCategory = new GameCategory(appTenant, gameName, gameSlug);
        }

        [Test]
        public void Slug_StringValue_InSlugForm() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"));
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameCategory gameCategory = new GameCategory(appTenant, gameName, gameName);

            // Assert
            Assert.AreEqual(gameName, gameCategory.Name);
            Assert.AreEqual(gameSlug, gameCategory.Slug);
        }


    }
}
