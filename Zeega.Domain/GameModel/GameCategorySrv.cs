using System.Collections.Generic;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game category service provides game category related actions
    /// </summary>
    public static class GameCategorySrv {
        /// <summary>
        /// Sets Sequence property of GameCategory based on enumerable collection of categories
        /// </summary>
        /// <param name="gameCategories">collection of game categories</param>
        public static void OrderGameCategories(IList<GameCategory> gameCategories) {
            short sequece = 0;
            foreach (var gameCategory in gameCategories) { gameCategory.Sequence = ++sequece; }
        }

    }
}
