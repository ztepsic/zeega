using System;
using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Class that represents mapping between two GameCategories where
    /// each GameInstanceCategory has different <see cref="AppTenant"/>.
    /// <example>
    /// GameInstanceCategory A with AppTenant A translates to (have match with some GameInstanceCategory in different AppTenant)
    /// GameInstanceCategory B with AppTenant B
    /// </example>
    /// </summary>
    class GameInstanceCategoryMapping : Entity {

        // TODO: http://lostechies.com/jimmybogard/2014/03/12/avoid-many-to-many-mappings-in-orms/
        #region Fields and Properties

        /// <summary>
        /// Game category FROM which we are mapping
        /// </summary>
        private readonly GameInstanceCategory gameInstanceCategoryFrom;

        /// <summary>
        /// Gets game category FROM which we are mapping
        /// </summary>
        public GameInstanceCategory GameInstanceCategoryFrom { get { return gameInstanceCategoryFrom; } }

        /// <summary>
        /// Game category TO which we are mapping
        /// </summary>
        private readonly GameInstanceCategory gameInstanceCategoryTo;

        /// <summary>
        /// Gets game category TO which we are mapping
        /// </summary>
        public GameInstanceCategory GameInstanceCategoryTo { get { return gameInstanceCategoryTo; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game category mapping for provided games categories
        /// </summary>
        /// <param name="gameInstanceCategoryFrom">Game category FROM which we are mapping</param>
        /// <param name="gameInstanceCategoryTo">Game category TO which we are mapping</param>
        public GameInstanceCategoryMapping(GameInstanceCategory gameInstanceCategoryFrom, GameInstanceCategory gameInstanceCategoryTo) {
            if(gameInstanceCategoryFrom == null) throw new ArgumentNullException("gameInstanceCategoryFrom", "Game category from can't be null.");
            if(gameInstanceCategoryTo == null) throw new ArgumentNullException("gameInstanceCategoryTo", "Game category to can't be null.");

            this.gameInstanceCategoryFrom = gameInstanceCategoryFrom;
            this.gameInstanceCategoryTo = gameInstanceCategoryTo;
        }

        #endregion

    }
}
