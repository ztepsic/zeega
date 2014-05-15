using System.Collections.Generic;
using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game categories repository interface
    /// </summary>
    public interface IGameCategoriesRepository  : ICrudRepository<GameCategory> {
        /// <summary>
        /// Get categories with assigned game instances for provided app tenant
        /// </summary>
        /// <param name="appTenant"></param>
        /// <returns>Game categories with assigned games instances</returns>
        IEnumerable<GameCategory> GetCategoriesWithGames(AppTenant appTenant);

    }
}
