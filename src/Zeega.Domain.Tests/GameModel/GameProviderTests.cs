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
            Assert.Multiple(() => {
                Assert.That(gameProvider, Is.Not.Null);
                Assert.That(gameProvider.Name, Is.EqualTo(gameProviderName));
                Assert.That(gameProvider.OfficialUrl, Is.EqualTo(gameProviderOfficialUrl));
            });
        }

    }
}
