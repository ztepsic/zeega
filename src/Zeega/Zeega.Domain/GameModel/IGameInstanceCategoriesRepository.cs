using System.Collections.Generic;
using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game instance categories repository interface
    /// </summary>
    public interface IGameInstanceCategoriesRepository : ICrudRepository<GameInstanceCategory> {
        /// <summary>
        /// Get categories with assigned game instances for provided app tenant
        /// </summary>
        /// <param name="appTenant"></param>
        /// <returns>Game categories with assigned games instances</returns>
        IEnumerable<GameInstanceCategory> GetCategoriesWithGames(AppTenant appTenant);

    }
}
