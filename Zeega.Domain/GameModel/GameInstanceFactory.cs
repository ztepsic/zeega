using System.Linq;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game instance factory
    /// </summary>
    public class GameInstanceFactory {

        #region Fields and Properties

        /// <summary>
        /// Tags repository
        /// </summary>
        private readonly ITagsRepository tagsRepository;

        /// <summary>
        /// Game category mapping repository
        /// </summary>
        private readonly IGameCategoryMappingsRepository gameCategoryMappingsRepository;


        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game instance factory
        /// </summary>
        /// <param name="tagsRepository">Tags repository</param>
        /// <param name="gameCategoryMappingsRepository">Game category mapping repository</param>
        public GameInstanceFactory(ITagsRepository tagsRepository, IGameCategoryMappingsRepository gameCategoryMappingsRepository) {
            this.tagsRepository = tagsRepository;
            this.gameCategoryMappingsRepository = gameCategoryMappingsRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new game instance based on existing game instance
        /// </summary>
        /// <param name="gameInstance">Game instance to make clone from</param>
        /// <param name="appTenant">Application tenant which is expected to be different from one in provided game instance.</param>
        /// <param name="gameInstanceName">Name of a new game instance</param>
        /// <returns>A new game instance with cloned vales based on provided game instance.</returns>
        public GameInstance CreateCloneOf(GameInstance gameInstance, AppTenant appTenant, string gameInstanceName) {
            var newGameInstance = GameInstance.CreateInstanceClone(gameInstance, appTenant, gameInstanceName);
            var gameInstanceTags = tagsRepository.GetTagsFor(gameInstance.Tags, appTenant.LanguageCode);
            foreach (var gameInstanceTag in gameInstanceTags) {
                newGameInstance.AddTag(gameInstanceTag);
            }

            var primaryCategory = gameCategoryMappingsRepository.GetMappedGameCategoryFrom(gameInstance.PrimaryCategory);
            if (primaryCategory != null) {
                newGameInstance.PrimaryCategory = primaryCategory;

                var secondaryCategories = gameCategoryMappingsRepository.GetMappedGameCategoriesFrom(gameInstance.SecondaryCategories);
                foreach (var secondaryCategory in secondaryCategories) {
                    newGameInstance.AddSecondaryCategory(secondaryCategory);
                }
            }

            return newGameInstance;
        }

        #endregion

    }
}
