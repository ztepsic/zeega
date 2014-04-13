using System;
using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Class that represents mapping between two GameCategories where
    /// each GameCategory has different <see cref="AppTenant"/>.
    /// <example>
    /// GameCategory A with AppTenant A translates to (have match with some GameCategory in different AppTenant)
    /// GameCategory B with AppTenant B
    /// </example>
    /// </summary>
    class GameCategoryMapping : Entity {

        // TODO: http://lostechies.com/jimmybogard/2014/03/12/avoid-many-to-many-mappings-in-orms/
        #region Fields and Properties

        /// <summary>
        /// Game category FROM which we are mapping
        /// </summary>
        private readonly GameCategory gameCategoryFrom;

        /// <summary>
        /// Gets game category FROM which we are mapping
        /// </summary>
        public GameCategory GameCategoryFrom { get { return gameCategoryFrom; } }

        /// <summary>
        /// Game category TO which we are mapping
        /// </summary>
        private readonly GameCategory gameCategoryTo;

        /// <summary>
        /// Gets game category TO which we are mapping
        /// </summary>
        public GameCategory GameCategoryTo { get { return gameCategoryTo; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game category mapping for provided games categories
        /// </summary>
        /// <param name="gameCategoryFrom">Game category FROM which we are mapping</param>
        /// <param name="gameCategoryTo">Game category TO which we are mapping</param>
        public GameCategoryMapping(GameCategory gameCategoryFrom, GameCategory gameCategoryTo) {
            if(gameCategoryFrom == null) throw new ArgumentNullException("gameCategoryFrom", "Game category from can't be null.");
            if(gameCategoryTo == null) throw new ArgumentNullException("gameCategoryTo", "Game category to can't be null.");

            this.gameCategoryFrom = gameCategoryFrom;
            this.gameCategoryTo = gameCategoryTo;
        }

        #endregion

    }
}
