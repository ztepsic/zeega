using System.Linq;
using NUnit.Framework;
using Zed.Core.Domain;
using Zeega.Domain;
using Zeega.Infrastructure.Dal;

namespace Zeega.Infrastructure.Tests.Dal {
    [TestFixture]
    public class TagsNhRepositoryTests : SQLiteNHibernateTestFixture {

        [Test]
        public void SaveOrUpdate_Tag_AddedToDb() {

            // Arrange
            var baseTag = Tag.CreateBaseTag("SportsEN");
            var tagsRepo = new TagsNhRepository(SessionFactory);

            // Act
            using (var trx = Session.BeginTransaction()) {
                tagsRepo.SaveOrUpdate(baseTag);
                trx.Commit();
            }

            // Assert
        }

        [Test]
        public void Get_Tag_FetchedTag() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("sportsEN");
            var tagsRepo = new TagsNhRepository(SessionFactory);

            // Act
            Tag fetchedBaseTag;
            using (var trx = Session.BeginTransaction()) {
                tagsRepo.SaveOrUpdate(baseTag);
                trx.Commit();
            }

            using (var trx = Session.BeginTransaction()) {
                fetchedBaseTag = tagsRepo.GetById(baseTag.Id);
                trx.Rollback();
           }

            // Assert
            Assert.IsNotNull(fetchedBaseTag);
            Assert.AreEqual(baseTag, fetchedBaseTag);
        }

        [Test]
        public void GetTagsFor_TagsAndLanguageCode_TagsInRequestedLanguage() {
            // Arrange
            var baseTag = Tag.CreateBaseTag("sportsEN");

            var langCodeHr = new LanguageCode("hr");
            var tag = Tag.CreateTag("sportHR", langCodeHr, baseTag);

            var tagsRepo = new TagsNhRepository(SessionFactory);

            using (var trx = Session.BeginTransaction()) {
                tagsRepo.SaveOrUpdate(tag);
                trx.Commit();
            }

            // Act
            var tagsResult = tagsRepo.GetTagsFor(new[] { baseTag }, langCodeHr);

            // Assert
            Assert.IsNotEmpty(tagsResult);
            Assert.AreEqual(tag, tagsResult.ToArray()[0]);

        }

    }
}
