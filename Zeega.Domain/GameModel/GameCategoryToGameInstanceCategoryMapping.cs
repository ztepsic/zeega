using System;
using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Entity class that represents game category to game instance category mapping
    /// </summary>
    public class GameCategoryToGameInstanceCategoryMapping : Entity {

        #region Fields and Properties

        /// <summary>
        /// Game category
        /// </summary>
        private readonly GameCategory gameCategory;

        /// <summary>
        /// Gets game category
        /// </summary>
        public virtual GameCategory GameCategory { get { return gameCategory; } }

        /// <summary>
        /// Game instance
        /// </summary>
        private readonly GameInstanceCategory gameInstanceCategory;

        /// <summary>
        /// Gets game instance
        /// </summary>
        public virtual GameInstanceCategory GameInstanceCategory { get { return gameInstanceCategory; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor
        /// </summary>
        protected GameCategoryToGameInstanceCategoryMapping() { }

        /// <summary>
        /// Creates game category to game category instance mapping
        /// </summary>
        /// <param name="gameCategory">Game category</param>
        /// <param name="gameInstanceCategory">Game instance category</param>
        public GameCategoryToGameInstanceCategoryMapping(GameCategory gameCategory, GameInstanceCategory gameInstanceCategory) {
            if(gameCategory == null) throw new ArgumentNullException("gameCategory", "Game category can't be null.");
            this.gameCategory = gameCategory;

            if (gameInstanceCategory == null) throw new ArgumentNullException("gameInstanceCategory", "Game instance category can't be null.");
            this.gameInstanceCategory = gameInstanceCategory;
        }

        #endregion

        #region Methods
        #endregion


    }
}
