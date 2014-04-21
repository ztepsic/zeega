using NUnit.Framework;
using Zed.Core.Domain;
using Zeega.Domain;
using Zeega.Infrastructure.Dal;

namespace Zeega.Infrastructure.Tests.Dal {
    [TestFixture]
    public class AppTenantsNhRepositoryTests : SQLiteNHibernateTestFixture {

        [Test]
        public void SaveOrUpdate_AppTenant_AddedToDb() {

            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var appTenantsRepo = new AppTenantsNhRepository(SessionFactory);

            // Act
            
           using (var trx = Session.BeginTransaction()) {
                appTenantsRepo.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            // Assert
        }

        [Test]
        public void Get_AppTenant_FetchedAppTenant() {

            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var appTenantsRepo = new AppTenantsNhRepository(SessionFactory);

            // Act
            AppTenant fetchedAppTenant;
            
            using (var trx = Session.BeginTransaction()) {
                appTenantsRepo.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            using (var trx = Session.BeginTransaction()) {
                appTenantsRepo.SaveOrUpdate(appTenant);
                trx.Commit();
            }

            using (var trx = Session.BeginTransaction()) {
                fetchedAppTenant = appTenantsRepo.GetById(appTenant.Id);
                trx.Rollback();
            }
            
            // Assert
            Assert.IsNotNull(fetchedAppTenant);
            Assert.AreEqual(appTenant, fetchedAppTenant);
        }

    }
}
