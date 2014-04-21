using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.GameModel {
    /// <summary>
    /// Game categories NHibernate repository
    /// </summary>
    public class GameCategoriesNhRepository : NHibernateCrudRepository<GameCategory>, IGameCategoriesRepository {

        #region Fields and Properties

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game categories NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GameCategoriesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods


        #endregion

    }
}
