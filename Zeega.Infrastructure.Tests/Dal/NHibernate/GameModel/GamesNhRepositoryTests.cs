using System;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.GameModel {
    [TestFixture]
    class GamesNhRepositoryTests : SQLiteNHibernateTestFixture {

        [Test]
        public void SaveOrUpdate_Game_AddedToDb() {
            // Arrange
            var game = new Game("Angry Birds") {
                GameSrc = new GameSrc(800, 600, "http://example.com/angry-birds", GameSrcType.Swf),
                Provider = "GameProvider",
                ProviderUrl = "http://www.example.com",
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
            var game = new Game("Angry Birds") {
                GameSrc = new GameSrc(800, 600, "http://example.com/angry-birds", GameSrcType.Swf),
                Provider = "GameProvider",
                ProviderUrl = "http://www.example.com",
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
