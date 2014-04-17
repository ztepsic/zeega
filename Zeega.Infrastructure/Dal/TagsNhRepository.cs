using NHibernate;
using Zed.NHibernate;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal {
    public class TagsNhRepository : NHibernateCrudRepository<Tag> {

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
        #endregion

    }
}
