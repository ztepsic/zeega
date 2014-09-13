using System;
using NUnit.Framework;
using Zed.Utilities;

namespace Zeega.Domain.Tests {
    [TestFixture]
    public class TagTests {

        [Test]
        public void CreateTag_WithDefaultLanguageCode_CreatedBaseTag() {
            // Arrange
            const string NAME = "Tower Defense";

            // Act
            var tag = Tag.CreateBaseTag(NAME);

            // Assert
            Assert.IsNotNull(tag);
            Assert.AreEqual(NAME, tag.Name);
            Assert.AreEqual(NAME.ToSlug(), tag.Slug);
            Assert.AreEqual(LanguageCode.ENGLISH_TWO_LETTER_CODE, tag.LanguageCode.ToString());
        }

        [Test]
        public void CreateTag_WithBaseTag_CreatedTag() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            const string NAME = "Nogomet";

            // Act
            var tag = Tag.CreateTag(NAME, new LanguageCode("hr"), baseTag);

            // Assert
            Assert.IsNotNull(tag);
            Assert.AreEqual(NAME, tag.Name);
            Assert.AreEqual(NAME.ToSlug(), tag.Slug);
            Assert.AreEqual("hr", tag.LanguageCode.Value);
            Assert.AreEqual(baseTag, tag.BaseTag);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTag_WithFakeBaseTag_ArgumentExceptionThrown() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            const string NAME = "Nogomet";
            var fakeBasetag = Tag.CreateTag(NAME, new LanguageCode("hr"), baseTag);

            // Act
            var tag = Tag.CreateTag(NAME, new LanguageCode("es"), fakeBasetag);

            // Assert
            
        }
    }
}
