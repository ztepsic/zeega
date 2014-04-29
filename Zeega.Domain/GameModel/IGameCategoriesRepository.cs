using System.Collections.Generic;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game categories repository interface
    /// </summary>
    public interface IGameCategoriesRepository {
        /// <summary>
        /// Get categories with assigned game instances for provided app tenant
        /// </summary>
        /// <param name="appTenant"></param>
        /// <returns>Game categories with assigned games instances</returns>
        IEnumerable<GameCategory> GetCategoriesWithGames(AppTenant appTenant);

    }
}
