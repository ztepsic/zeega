using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Zed.NHibernate;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate {
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
            return from tag in Session.Query<Tag>()
                where tags.Select(t => t.BaseTag ?? t).Contains(tag.BaseTag) &&
                      tag.LanguageCode == languageCode
                select tag;
        }

        #endregion

    }
}
