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


        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game instance factory
        /// </summary>
        /// <param name="tagsRepository">Tags repository</param>
        public GameInstanceFactory(ITagsRepository tagsRepository) {
            this.tagsRepository = tagsRepository;
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

            return newGameInstance;
        }

        #endregion

    }
}
