using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.GameModel {
    [TestFixture]
    class GameCategoriesNhRepositoryTests : SQLiteNHibernateTestFixture {

        private AppTenant createAppTenant() {
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            return appTenant;
        }

        [Test]
        public void SaveOrUpdate_GameCategory_AddedToDb() {
            // Arrange
            var appTenant = createAppTenant();
            var gameCategory = new GameCategory(appTenant, "Sports");

            var gameCategoriesRepo = new GameCategoriesNhRepository(SessionFactory);

            // Act
            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategory);
                trx.Commit();
            }


            // Assert
        }

        [Test]
        public void Get_GameCategry_FetchedGameCategory() {
            // Arrange
            var appTenant = createAppTenant();
            var gameCategory = new GameCategory(appTenant, "Sports");

            var gameCategoriesRepo = new GameCategoriesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategory);
                trx.Commit();
            }

            // Act
            GameCategory fetchedGameCategory = null;
            using (var trx = Session.BeginTransaction()) {
                fetchedGameCategory = gameCategoriesRepo.GetById(gameCategory.Id);
                trx.Commit();
            }
            
            // Assert
            Assert.IsNotNull(fetchedGameCategory);
            Assert.AreEqual(gameCategory, fetchedGameCategory);
        }

    }
}
