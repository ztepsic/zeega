using System;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.GameModel {
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
            var game = new Game("Angry Birds") {
                GameSrc = new GameSrc(800, 600, "http://example.com/angry-birds", GameSrcType.Swf),
                Provider = "GameProvider",
                ProviderUrl = "http://www.example.com",
                ProviderGameUrl = "http://www.example.com/angry-birds",
                Audit = new Audit(DateTime.Now)
            };

            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(game);
                trx.Commit();
            }

            return game;
        }

        private GameCategory createGameCategory(AppTenant appTenant) {
            var gameCategory = new GameCategory(appTenant, "Sports");
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(gameCategory);
                trx.Commit();
            }
            return gameCategory;
        }

        [Test]
        public void SaveOrUpdate_GameInstance_AddedToDb() {
            // Arrange
            var appTenant = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = createGame();
            var gameCategory = createGameCategory(appTenant);
            var gameInstance = new GameInstance(appTenant, game) {
                PrimaryCategory = gameCategory
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
