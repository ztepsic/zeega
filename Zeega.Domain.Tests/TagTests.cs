using System;
using NUnit.Framework;
using Zed.Core.Utilities;

namespace Zeega.Domain.Tests {
    [TestFixture]
    public class TagTests {

        [Test]
        public void CreateTag_WithPrimaryAppTenant_CreatedTag() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            const string NAME = "Tower Defense";

            // Act
            var tag = Tag.CreateTag(NAME, appTenant);

            // Assert
            Assert.IsNotNull(tag);
            Assert.AreEqual(NAME, tag.Name);
            Assert.AreEqual(NAME.ToSlug(), tag.Slug);
            Assert.AreEqual(appTenant.LanguageCode, tag.LanguageCode);
        }

        [Test]
        public void CreateTag_WithBaseTag_CreatedTag() {
            // Arrange
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            var baseTag = Tag.CreateTag("Football", appTenant);
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
            var appTenant = new AppTenant("Zeega", new LanguageCode("en"), true);
            var baseTag = Tag.CreateTag("Football", appTenant);
            const string NAME = "Nogomet";
            var fakeBasetag = Tag.CreateTag(NAME, new LanguageCode("hr"), baseTag);

            // Act
            var tag = Tag.CreateTag(NAME, new LanguageCode("es"), fakeBasetag);

            // Assert
            
        }
    }
}
