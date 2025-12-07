using NHibernate;
using Zed.NHibernate;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories {
    /// <summary>
    /// Tags NHibernate repository
    /// </summary>
    public class TagsNhRepository : NHibernateCrudRepository<Tag>, ITagsRepository {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates an instance of NHibernate tags repository
        /// </summary>
        /// <param name="sessionFactory"></param>
        public TagsNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets tags in particular language for provided tags
        /// </summary>
        /// <param name="tags">Tags in other language</param>
        /// <param name="languageCode">Language for which we want tags</param>
        /// <returns>Tags in particular language if they exists, otherwise empty collection</returns>
        public IEnumerable<Tag> GetTagsFor(IList<Tag> tags, LanguageCode languageCode) {
            var baseTags = tags.Select(t => t.BaseTag ?? t).ToList();
            return from tag in Session.Query<Tag>()
                   where baseTags.Contains(tag.BaseTag) &&
                         tag.LanguageCode == languageCode
                   select tag;
        }

        /// <summary>
        /// Gets tag for particular tag example
        /// </summary>
        /// <param name="exampleTag">Example to search for</param>
        /// <returns>Tag that satisfies example</returns>
        public Tag GetByExample(Tag exampleTag) {
            //var criteria = Session.CreateCriteria<Tag>();
            //criteria.Add(Example.Create(exampleTag));
            //criteria.SetMaxResults(1);
            //return criteria.UniqueResult<Tag>();

            return (from tag in Session.Query<Tag>()
                    where tag.Slug.Equals(exampleTag.Slug)
                       && tag.LanguageCode == exampleTag.LanguageCode
                    select tag)
                    .Take(1)
                    .FirstOrDefault();

            //return Session.QueryOver<Tag>()
            //    .Where(x => x.LanguageCode == exampleTag.LanguageCode)
            //    .Select(x => x)
            //    .Take(1)
            //    .SingleOrDefault();
        }

        #endregion

    }
}
