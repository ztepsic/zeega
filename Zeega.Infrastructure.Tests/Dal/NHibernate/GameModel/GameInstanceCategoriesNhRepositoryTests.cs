using System;
using System.Linq;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.GameModel {
    [TestFixture]
    class GameInstanceCategoriesNhRepositoryTests : SQLiteNHibernateTestFixture {

        private AppTenant createAppTenant(LanguageCode languageCode) {
            var appTenant = new AppTenant(String.Format("AppTenant{0}", languageCode.Value), languageCode);
            using (var trx = Session.BeginTransaction()) {
                Session.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            return appTenant;
        }

        [Test]
        public void SaveOrUpdate_GameCategory_AddedToDb() {
            // Arrange
            var appTenant = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var gameCategory = new GameInstanceCategory(appTenant, "Sports");

            var gameCategoriesRepo = new GameInstanceCategoriesNhRepository(SessionFactory);

            // Act
            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategory);
                trx.Commit();
            }


            // Assert
        }

        [Test]
        public void Get_GameInstanceCategory_FetchedGameInstanceCategory() {
            // Arrange
            var appTenant = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var gameInstanceCategory = new GameInstanceCategory(appTenant, "Sports");

            var gameInstanceCategoriesRepo = new GameInstanceCategoriesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gameInstanceCategoriesRepo.SaveOrUpdate(gameInstanceCategory);
                trx.Commit();
            }

            Session.Clear(); // To clear cache so we can see select

            // Act
            GameInstanceCategory fetchedGameInstanceCategory = null;
            using (var trx = Session.BeginTransaction()) {
                fetchedGameInstanceCategory = gameInstanceCategoriesRepo.GetById(gameInstanceCategory.Id);
                trx.Commit();
            }
            
            // Assert
            Assert.IsNotNull(fetchedGameInstanceCategory);
            Assert.AreEqual(gameInstanceCategory, fetchedGameInstanceCategory);
        }

        [Test]
        public void GetCategoriesWithGames_AppTenant_FetchedCategoriesWithAssignedGames() {
            // Arrange
            var appTenantEn = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var appTenantHr = createAppTenant(new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameCategoryWithGamesEn = new GameInstanceCategory(appTenantEn, "WithGames");
            var gameCategoryWithoutGamesEn = new GameInstanceCategory(appTenantEn, "WithoutGames");
            var gameCategoryWithGamesHr = new GameInstanceCategory(appTenantHr, "WithGames");

            var gameCategoriesRepo = new GameInstanceCategoriesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithGamesEn);
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithoutGamesEn);
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithGamesHr);
                trx.Commit();
            }

            Session.Clear(); // To clear cache so we can see select

            // Act
            GameInstanceCategory[] instanceCategoriesWithGamesInstance = null;
            using (var trx = Session.BeginTransaction()) {
                instanceCategoriesWithGamesInstance = gameCategoriesRepo.GetCategoriesWithGames(appTenantEn).ToArray();
                trx.Commit();
            }

            // Assert
            Assert.AreEqual(0, instanceCategoriesWithGamesInstance.Length);
        }

    }
}
