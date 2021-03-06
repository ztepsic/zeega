﻿using System.Collections.Generic;


namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game category mapping repository interface
    /// </summary>
    public interface IGameCategoryMappingsRepository {
        /// <summary>
        /// Gets game category which is mapped from provided game category
        /// </summary>
        /// <param name="gameInstanceCategory">Game category from which is mapped</param>
        /// <returns>Game category which is mapped from provided game category</returns>
        GameInstanceCategory GetMappedGameCategoryFrom(GameInstanceCategory gameInstanceCategory);

        /// <summary>
        /// Games game categories which are mapped from provided collection of games categories
        /// </summary>
        /// <param name="gameCategories">Collection of game categories from which is mapped</param>
        /// <returns>Collection of game categories which are mapped from proviede collection of game categories </returns>
        IEnumerable<GameInstanceCategory> GetMappedGameCategoriesFrom(IEnumerable<GameInstanceCategory> gameCategories);
    }
}
