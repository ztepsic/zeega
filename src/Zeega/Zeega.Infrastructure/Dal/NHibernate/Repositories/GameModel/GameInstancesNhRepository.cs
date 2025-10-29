using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel {
    /// <summary>
    /// Game instances NHibernate repository
    /// </summary>
    public class GameInstancesNhRepository : NHibernateCrudRepository<GameInstance> {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game instances NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GameInstancesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods
        #endregion
    }
}
