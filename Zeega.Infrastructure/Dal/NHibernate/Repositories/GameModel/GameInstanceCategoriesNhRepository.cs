using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Zed.NHibernate;
using Zeega.Domain;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel {
    /// <summary>
    /// Game categories NHibernate repository
    /// </summary>
    public class GameInstanceCategoriesNhRepository : NHibernateCrudRepository<GameInstanceCategory>, IGameInstanceCategoriesRepository {

        #region Fields and Properties

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game categories NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GameInstanceCategoriesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        /// <summary>
        /// Get categories with assigned game instances for provided language code
        /// </summary>
        /// <param name="appTenant"></param>
        /// <returns>Game categories with assigned game instances</returns>
        public IEnumerable<GameInstanceCategory> GetCategoriesWithGames(AppTenant appTenant) {
            return from category in Session.Query<GameInstanceCategory>()
                   where category.AppTenant == appTenant
                   && (from gameInstance in Session.Query<GameInstance>()
                       where gameInstance.PrimaryInstanceCategory == category
                       || gameInstance.SecondaryCategories.Contains(category)
                       select gameInstance
                          ).Any()
                   orderby category.Sequence
                   select category;
        }

        #endregion
    }
}
