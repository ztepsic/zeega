using System;
using System.Linq;
using NUnit.Framework;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.GameModel {
    [TestFixture]
    class GameCategoriesNhRepositoryTests : SQLiteNHibernateTestFixture {

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
            var appTenant = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var gameCategory = new GameCategory(appTenant, "Sports");

            var gameCategoriesRepo = new GameCategoriesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategory);
                trx.Commit();
            }

            Session.Clear(); // To clear cache so we can see select

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

        [Test]
        public void GetCategoriesWithGames_AppTenant_FetchedCategoriesWithAssignedGames() {
            // Arrange
            var appTenantEn = createAppTenant(new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var appTenantHr = createAppTenant(new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameCategoryWithGamesEn = new GameCategory(appTenantEn, "WithGames");
            var gameCategoryWithoutGamesEn = new GameCategory(appTenantEn, "WithoutGames");
            var gameCategoryWithGamesHr = new GameCategory(appTenantHr, "WithGames");

            var gameCategoriesRepo = new GameCategoriesNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithGamesEn);
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithoutGamesEn);
                gameCategoriesRepo.SaveOrUpdate(gameCategoryWithGamesHr);
                trx.Commit();
            }

            Session.Clear(); // To clear cache so we can see select

            // Act
            GameCategory[] categoriesWithGames = null;
            using (var trx = Session.BeginTransaction()) {
                categoriesWithGames = gameCategoriesRepo.GetCategoriesWithGames(appTenantEn).ToArray();
                trx.Commit();
            }

            // Assert
            Assert.AreEqual(0, categoriesWithGames.Length);
        }

    }
}
