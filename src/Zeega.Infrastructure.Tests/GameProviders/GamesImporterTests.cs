using Moq;
using Zed.Domain;
using Zed.NHibernate;
using Zeega.Domain.GameModel;
using Zeega.Domain.GameProviders;
using Zeega.Infrastructure.Dal.NHibernate.Repositories.GameProviders;
using Zeega.Infrastructure.GameProviders;
using Zeega.Infrastructure.GameProviders.GameDistribution;
using Zeega.Infrastructure.Tests.Dal.NHibernate;

namespace Zeega.Infrastructure.Tests.GameProviders {
    [TestFixture]
    public class GamesImporterTests : SQLiteNHibernateTestFixture {
        [Test]
        public void ImportGameDistribution() {
            // Arrange
            var gameDistributionGameProvider = new GameProvider("Game Distribution");
            gameDistributionGameProvider.SetIdTo((int)GameProvidersEnum.GameDistribution);

            var gameProvidersRepositoryMock = new Mock<IGameProvidersRepository>();
            gameProvidersRepositoryMock
                .Setup(x => x.GetById((int)GameProvidersEnum.GameDistribution))
                .Returns(gameDistributionGameProvider);

            var gameDistributionProviderMock = new Mock<IGameDistributionProvider>();
            gameDistributionProviderMock
                .Setup(x => x.FetchGamesFeedCombined(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<GameDiscributionGameType>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<GameDistributionGame>());

            var gameProvidersRepository = gameProvidersRepositoryMock.Object;
            var gamesImportsRepository = new GamesImportNhRepository(SessionFactory);
            var gameDistributionGamesRepository = new GameDistributinGamesNhRepository(SessionFactory);
            var gamesImporter = new GamesImporter(gameProvidersRepository, gamesImportsRepository, gameDistributionGamesRepository, gameDistributionProviderMock.Object);

            var unitOfWorkManager = new NHibernateUnitOfWorkManager(SessionFactory);

            // Act
            using (var scope = unitOfWorkManager.Start()) {
                gamesImporter.ImportGameDistribution(scope);
                scope.Commit();
            }

            // Assert

        }
    }
}
