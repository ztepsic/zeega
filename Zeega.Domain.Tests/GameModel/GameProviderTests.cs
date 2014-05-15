using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameProviderTests {

        [Test]
        public void Ctr_WithParams_CreatesGameProviderInstance() {
            // Arrange
            const string gameProviderName = "Spil Games";
            const string gameProviderOfficialUrl = "http://www.spilgames.com";

            // Act
            var gameProvider = new GameProvider(gameProviderName) {
                OfficialUrl = gameProviderOfficialUrl
            };

            // Assert
            Assert.IsNotNull(gameProvider);
            Assert.AreEqual(gameProviderName, gameProvider.Name);
            Assert.AreEqual(gameProviderOfficialUrl, gameProvider.OfficialUrl);
        }

    }
}
