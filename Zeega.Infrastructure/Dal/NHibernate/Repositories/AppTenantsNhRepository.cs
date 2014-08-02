using NHibernate;
using Zed.NHibernate;
using Zeega.Domain;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories {
    /// <summary>
    /// Application tenant NHibernate repository
    /// </summary>
    public class AppTenantsNhRepository : NHibernateCrudRepository<AppTenant>, IAppTenantsRepository {

        #region Fields and Properties
        #endregion

        #region Constructors and Init
        
        /// <summary>
        /// Creates an instance of NHibernate application tenants repository
        /// </summary>
        /// <param name="sessionFactory"></param>
        public AppTenantsNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        #endregion

    }
}
