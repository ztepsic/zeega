using System;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameCategoryTests {

        [Test]
        public void Ctr_WithParams_CreatesGameCategoryInstance() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameCategory gameCategory = new GameCategory(gameName);

            // Assert
            Assert.AreEqual(gameName, gameCategory.Name);
            Assert.AreEqual(gameSlug, gameCategory.Slug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_NullString_ExceptionThrown() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = null;

            // Act
            GameCategory gameCategory = new GameCategory(gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_WhiteSpaceString_ExceptionThrown() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = "     ";

            // Act
            GameCategory gameCategory = new GameCategory(gameName, gameSlug);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Slug_EmptyString_ExceptionThrown() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = string.Empty;

            // Act
            GameCategory gameCategory = new GameCategory(gameName, gameSlug);
        }

        [Test]
        public void Slug_StringValue_InSlugForm() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = "adventure-rpg";

            // Act
            GameCategory gameCategory = new GameCategory(gameName, gameName);

            // Assert
            Assert.AreEqual(gameName, gameCategory.Name);
            Assert.AreEqual(gameSlug, gameCategory.Slug);
        }


    }
}
