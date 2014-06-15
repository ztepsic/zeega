using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.GameModel {
    /// <summary>
    /// Games NHibernate repository
    /// </summary>
    public class GamesNhRepository : NHibernateCrudRepository<Game> {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates games NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GamesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods
        #endregion
    }
}
