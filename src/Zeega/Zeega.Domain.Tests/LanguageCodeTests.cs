namespace Zeega.Domain.Tests {
    [TestFixture]
    public class LanguageCodeTests {

        [Test]
        public void Ctr_TwoLetterLanguageCode_CreatedInstanceOfLanguageCode() {
            // Arrange

            // Act
            var languageCode = new LanguageCode("en");

            // Assert
            Assert.That(languageCode, Is.Not.Null);
            Assert.That(languageCode.Value, Is.EqualTo("en"));
        }

        [Test]
        public void Ctr_InvalidTwoLetterLanguageCode_ArgumentExceptionThrown() {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new LanguageCode("enabc"));
        }


        [Test]
        public void LanguageCode_WithAllUpperCharacters_LanguageCodeWithAllLowerCharacters() {
            // Arrange
            const string languageCodeStr = "EN";

            // Act
            var languageCode = new LanguageCode(languageCodeStr);

            // Assert
            Assert.That(languageCodeStr.ToLower(), Is.EqualTo(languageCode.Value));
        }

    }
}
