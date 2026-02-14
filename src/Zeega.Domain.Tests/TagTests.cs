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
            Assert.Multiple(() => {
                Assert.That(tag, Is.Not.Null);
                Assert.That(tag.Name, Is.EqualTo(NAME));
                Assert.That(tag.Slug, Is.EqualTo(NAME.ToSlug()));
                Assert.That(tag.LanguageCode.ToString(), Is.EqualTo(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            });

        }

        [Test]
        public void CreateTag_WithBaseTag_CreatedTag() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            const string NAME = "Nogomet";

            // Act
            var tag = Tag.CreateTag(NAME, new LanguageCode("hr"), baseTag);

            // Assert
            Assert.Multiple(() => {
                Assert.That(tag, Is.Not.Null);
                Assert.That(tag.Name, Is.EqualTo(NAME));
                Assert.That(tag.Slug, Is.EqualTo(NAME.ToSlug()));
                Assert.That(tag.LanguageCode.Value, Is.EqualTo("hr"));
                Assert.That(tag.BaseTag, Is.EqualTo(baseTag));
            });
        }

        [Test]
        public void CreateTag_WithFakeBaseTag_ArgumentExceptionThrown() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("Football");
            const string NAME = "Nogomet";
            var fakeBasetag = Tag.CreateTag(NAME, new LanguageCode("hr"), baseTag);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Tag.CreateTag(NAME, new LanguageCode("es"), fakeBasetag));

        }
    }
}
