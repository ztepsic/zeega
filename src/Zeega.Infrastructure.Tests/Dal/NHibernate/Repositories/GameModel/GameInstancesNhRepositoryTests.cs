using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.Repositories.GameModel {
    [TestFixture]
    class GameInstancesNhRepositoryTests : SQLiteNHibernateTestFixture {

        private AppTenant createAppTenant(LanguageCode languageCode) {
            var appTenant = new AppTenant(string.Format("AppTenant{0}", languageCode.Value), languageCode);
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            return appTenant;
        }

        private Game createGame() {
            var gameProvider = createGameProvider("Spil Games");
            var game = new Game("Angry Birds", gameProvider) {
                GameSrc = GameSrc.CreateGameSrcWithUrl(800, 600, GameSrcType.Swf, "http://example.com/angry-birds"),
                ProviderGameUrl = "http://www.example.com/angry-birds",
                ChangeStamp = new ChangeStamp(DateTime.Now)
            };

            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(game);
                trx.Commit();
            }

            return game;
        }

        private GameInstanceCategory createGameCategory(AppTenant appTenant) {
            var gameCategory = new GameInstanceCategory(appTenant, "Sports");
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(gameCategory);
                trx.Commit();
            }
            return gameCategory;
        }

        private GameProvider createGameProvider(string providerName) {
            var gameProvider = new GameProvider(providerName) {
                OfficialUrl = "http://www.spilgames.com"
            };
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(gameProvider);
                trx.Commit();
            }

            return gameProvider;
        }

        [Test]
        public void SaveOrUpdate_GameInstance_AddedToDb() {
            // Arrange
            var appTenant = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = createGame();
            var gameCategory = createGameCategory(appTenant);
            var gameInstance = new GameInstance(appTenant, game) {
                PrimaryInstanceCategory = gameCategory
            };

            var gameInstancesRepo = new GameInstancesNhRepository(SessionFactory);

            // Act
            using (var trx = Session.BeginTransaction()) {
                gameInstancesRepo.SaveOrUpdate(gameInstance);
                trx.Commit();
            }

            // Assert
        }

    }
}
