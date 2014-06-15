using System;
using NUnit.Framework;

namespace Zeega.Domain.Tests {
    [TestFixture]
    public class LanguageCodeTests {

        [Test]
        public void Ctr_TwoLetterLanguageCode_CreatedInstanceOfLanguageCode() {
            // Arrange

            // Act
            var languageCode = new LanguageCode("en");

            // Assert
            Assert.IsNotNull(languageCode);
            Assert.AreEqual("en", languageCode.Value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctr_InvalidTwoLetterLanguageCode_ArgumentExceptionThrown() {
            // Arrange

            // Act
            var languageCode = new LanguageCode("enabc");

            // Assert
        }


        [Test]
        public void LanguageCode_WithAllUpperCharacters_LanguageCodeWithAllLowerCharacters() {
            // Arrange
            const string languageCodeStr = "EN";

            // Act
            var languageCode = new LanguageCode(languageCodeStr);

            // Assert
            Assert.AreEqual(languageCodeStr.ToLower(), languageCode.Value);
        }

    }
}
