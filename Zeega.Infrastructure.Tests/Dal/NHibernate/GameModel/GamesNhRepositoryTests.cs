using System;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.GameModel {
    [TestFixture]
    class GamesNhRepositoryTests : SQLiteNHibernateTestFixture {

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
        public void SaveOrUpdate_Game_AddedToDb() {
            // Arrange
            var gameProvider = createGameProvider("Spil Games");
            var game = new Game("Angry Birds", gameProvider) {
                GameSrc = new GameSrc(800, 600, "http://example.com/angry-birds", GameSrcType.Swf),
                ProviderGameUrl = "http://www.example.com/angry-birds",
                Audit = new Audit(DateTime.Now)
            };

            var gamesRepo = new GamesNhRepository(SessionFactory);

            // Act
            using (var trx = Session.BeginTransaction()) {
                gamesRepo.SaveOrUpdate(game);
                trx.Commit();
            }

            // Assert
        }

        [Test]
        public void Get_Game_FetchedGame() {
            // Arrange
            var gameProvider = createGameProvider("Spil Games");
            var game = new Game("Angry Birds", gameProvider) {
                GameSrc = new GameSrc(800, 600, "http://example.com/angry-birds", GameSrcType.Swf),
                ProviderGameUrl = "http://www.example.com/angry-birds",
                Audit = new Audit(DateTime.Now)
            };

            var gamesRepo = new GamesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gamesRepo.SaveOrUpdate(game);
                trx.Commit();
            }
            Session.Clear(); // To clear cache so we can see select

            // Act
            Game fetchedGame = null;
            using (var trx = Session.BeginTransaction()) {
                fetchedGame = gamesRepo.GetById(game.Id);
                trx.Commit();
            }

            // Assert
            Assert.AreEqual(game, fetchedGame);
        }
    }
}
