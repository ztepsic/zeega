using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel {
    /// <summary>
    /// Game provider NHibernate repository
    /// </summary>
    public class GameProvidersNhRepository : NHibernateCrudRepository<GameProvider>, IGameProvidersRepository {

        #region Fields and Properties

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game categories NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GameProvidersNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods


        #endregion
    }
}
