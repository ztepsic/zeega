using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Zeega.Domain.Game;

namespace Zeega.Domain.Tests.Game {
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Slug_NullString_ExceptionThrown() {
            // Arrange
            string gameName = "Adventure & RPG";
            string gameSlug = null;

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
