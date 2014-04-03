using System;
using System.Linq;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameTests {

        #region Tests

        [Test]
        public void Ctor_WithParams_CreatesGame() {
            // Arrange
            const string gameName = "Angry birds";

            // Act
            var game = new Game(gameName);

            // Assert
            Assert.AreEqual(gameName, game.Name);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Height_InvalidHeight_ExceptionTrown() {
            // Arrange

            // Act
            var game = new Game("Angry birds");

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Width_InvalidWidth_ExceptionTrown() {
            // Arrange

            // Act
            var game = new Game("Angry birds");

            // Assert
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Create_ExistingGameInstance_NewGameInstanceWithCopiedValuesFromPassedGameArgument() {
            // Arrange

            // Act

            // Assert
        }

        #endregion
    }
}
