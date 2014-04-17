using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Driver;
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
            using (var session = SessionFactory.OpenSession()) {
                using (var trx = session.BeginTransaction()) {
                    tagsRepo.SaveOrUpdate(baseTag);
                    trx.Commit();
                }
            }

            // Assert
        }

        [Test]
        public void Get_Tag_FetchedTag() {

            // Arrange
            const int tagId = 123;
            var baseTag = Tag.CreateBaseTag("sportsEN");
            baseTag.SetIdTo(tagId);
            var tagsRepo = new TagsNhRepository(SessionFactory);

            // Act
            Tag fetchedBaseTag;
            using (var session = SessionFactory.OpenSession()) {
                using (var trx = session.BeginTransaction()) {
                    tagsRepo.SaveOrUpdate(baseTag);
                    trx.Commit();
                }

                using (var trx = session.BeginTransaction()) {
                    fetchedBaseTag = tagsRepo.GetById(tagId);
                    trx.Rollback();
                }
            }

            // Assert
            Assert.IsNotNull(fetchedBaseTag);
            Assert.AreEqual(baseTag, fetchedBaseTag);
        }

    }
}
