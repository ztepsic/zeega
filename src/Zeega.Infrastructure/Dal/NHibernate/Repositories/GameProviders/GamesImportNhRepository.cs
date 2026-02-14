using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameProviders;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameProviders {
    /// <summary>
    /// Games NHibernate repository
    /// </summary>
    public class GamesImportNhRepository : NHibernateCrudRepository<GamesImport>, IGamesImportsRepository {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates games imports NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GamesImportNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        #endregion
    }
}
