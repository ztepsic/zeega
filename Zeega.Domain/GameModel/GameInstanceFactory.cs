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

            var primaryCategory = gameCategoryMappingsRepository.GetMappedGameCategoryFrom(gameInstance.PrimaryInstanceCategory);
            if (primaryCategory != null) {
                newGameInstance.PrimaryInstanceCategory = primaryCategory;

                var secondaryCategories = gameCategoryMappingsRepository.GetMappedGameCategoriesFrom(gameInstance.SecondaryCategories);
                foreach (var secondaryCategory in secondaryCategories) {
                    newGameInstance.AddSecondaryCategory(secondaryCategory);
                }
            }

            return newGameInstance;
        }


        /// <summary>
        /// Creates a new game instance where some of game properties are copied to game instance properties
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game instance</param>
        /// <param name="game">Game upon which will be defined game instance</param>
        /// <returns>A new game instance with some of the properties filled with game ones. </returns>
        public GameInstance CreateWithGamePropertyCopy(AppTenant appTenant, Game game) {
            return CreateWithGamePropertyCopy(appTenant, game, game.Name);
        } 

        /// <summary>
        /// Creates a new game instance where some of game properties are copied to game instance properties
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game instance</param>
        /// <param name="game">Game upon which will be defined game instance</param>
        /// <param name="name">Game instance name</param>
        /// <returns>A new game instance with some of the properties filled with game ones. </returns>
        public GameInstance CreateWithGamePropertyCopy(AppTenant appTenant, Game game, string name) {
            var gameInstance = new GameInstance(appTenant, game, name) {
                Description = game.Description,
                ShortDescription = game.ShortDescription,
                Instructions = game.Instructions
            };

            var tags = tagsRepository.GetTagsFor(game.Tags, appTenant.LanguageCode);

            foreach (var tag in tags) {
                gameInstance.AddTag(tag);
            }

            return gameInstance;

        }

        #endregion

    }
}
