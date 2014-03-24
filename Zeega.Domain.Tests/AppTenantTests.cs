using NUnit.Framework;

namespace Zeega.Domain.Tests {
    [TestFixture]
    public class AppTenantTests {

        #region Tests

        [Test]
        public void Ctr_WithParams_CreatedInstanceOfAppTenant() {
            // Arrange
            const string name = "Zeega";
            const string languageCode = "en";

            // Act
            var appTenant = new AppTenant(name, languageCode);

            // Assert
            Assert.IsNotNull(appTenant);
            Assert.AreEqual(name, appTenant.Name);
            Assert.AreEqual(languageCode, appTenant.LanguageCode);
        }

        [Test]
        public void LanguageCode_WithAllUpperCharacters_LanguageCodeWithAllLowerCharacters() {
            // Arrange
            const string name = "Zeega";
            const string languageCode = "EN";

            // Act
            var appTenant = new AppTenant(name, languageCode);

            // Assert
            Assert.IsNotNull(appTenant);
            Assert.AreEqual(name, appTenant.Name);
            Assert.AreEqual(languageCode.ToLower(), appTenant.LanguageCode);
        }

        #endregion

    }
}
