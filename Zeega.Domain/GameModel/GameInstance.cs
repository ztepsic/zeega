using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zed.Core.Domain;
using Zed.Core.Utilities;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// An entity that represents game instance per application tenant
    /// </summary>
    public class GameInstance : Entity {

        #region Constants

        /// <summary>
        /// Maximum number of characters for short description
        /// </summary>
        public const int MAX_CHARS_FOR_SHORT_DESCRIPTION = 300;

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Application tenant that owns this game instance
        /// </summary>
        private readonly AppTenant appTenant;

        /// <summary>
        /// Gets application tenant that owns this game instance
        /// </summary>
        public AppTenant AppTenant { get { return appTenant; } }

        /// <summary>
        /// Game upon which is defined this game instance
        /// </summary>
        private readonly Game game;

        /// <summary>
        /// Gets game Id
        /// </summary>
        public int GameId { get { return game.Id; } }

        /// <summary>
        /// Game instance name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets game instance name
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game name must contain some value.");

                name = value;
            }
        }

        /// <summary>
        /// Unique text slug
        /// </summary>
        private string slug;

        /// <summary>
        /// Gets unique text slug
        /// </summary>
        public string Slug { get { return slug; } }

        /// <summary>
        /// Primary game category
        /// </summary>
        private GameCategory primaryCategory;

        /// <summary>
        /// Gets or Sets game category
        /// </summary>
        public GameCategory PrimaryCategory {
            get { return primaryCategory; }
            set {
                if(value == null) throw new ArgumentNullException("value", "Primary category can't be null.");
                if(!AppTenant.Equals(value.AppTenant)) throw new ArgumentException("Game category application tenant must be equal as Game instance application tenant.");

                primaryCategory = value;
            }
        }

        /// <summary>
        /// List of secondary game instance categories
        /// </summary>
        private readonly IList<GameCategory> secondaryCategories;

        /// <summary>
        /// Gets list of secondary game instance categories
        /// </summary>
        public IList<GameCategory> SecondaryCategories {
            get { return new ReadOnlyCollection<GameCategory>(secondaryCategories); }
        }

        /// <summary>
        /// Gets or Sets the full text description of the game instance.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Short text description of the game instance.
        /// Includes up to 300 characters.
        /// </summary>
        private string shortDescription;

        /// <summary>
        /// Gets or Sets short text description of game instance.
        /// Includes up to 300 characters.
        /// </summary>
        public string ShortDescription {
            get { return shortDescription; }
            set {
                if (value != null && value.Length > MAX_CHARS_FOR_SHORT_DESCRIPTION) {
                    throw new ArgumentException(String.Format("Short description must have total lenght up to {0} characters.", MAX_CHARS_FOR_SHORT_DESCRIPTION));
                }

                shortDescription = value;
            }
        }

        /// <summary>
        /// Gets or Sets game instructions
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// JSON encoded key-value mapping of the games controls
        /// TODO - create better controls mapping
        /// </summary>
        public string Controls { get; set; }


        /// <summary>
        /// List of game instance tags/keywords
        /// </summary>
        private readonly IList<Tag> tags;

        /// <summary>
        /// Gets list of game instance tags/keywords
        /// </summary>
        public IList<Tag> Tags {
            get { return new ReadOnlyCollection<Tag>(tags); }
        }

        /// <summary>
        /// Indicates if game instance is published (true) or not (false)
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets game source
        /// </summary>
        public GameSrc GameSrc { get { return game.GameSrc; } }

        /// <summary>
        /// Gets game's media resources
        /// </summary>
        public IList<MediaRes> MediaResources { get { return game.MediaResources; } }

        /// <summary>
        /// Gets or Sets Audit
        /// </summary>
        public Audit Audit { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game instance with provded paramaters.
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game instance</param>
        /// <param name="game">Game upon which will be defined game instance</param>
        public GameInstance(AppTenant appTenant, Game game) : this(appTenant, game, game.Name) { }

        /// <summary>
        /// Creates game instance with provded paramaters.
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game instance</param>
        /// <param name="game">Game upon which will be defined game instance</param>
        /// <param name="name">Game instance name</param>
        public GameInstance(AppTenant appTenant, Game game, string name) {
            if (appTenant == null) throw new ArgumentNullException("appTenant", "Application tenant can't be null.");
            this.appTenant = appTenant;

            if(game == null) throw new ArgumentNullException("game", "Game can't be null.");
            this.game = game;

            Name = name;
            SetSlug(Name);

            secondaryCategories = new List<GameCategory>();
            tags = new List<Tag>();

            mapGameToGameInstance();
            
        }

        /// <summary>
        /// Maps game properties to game instance properties
        /// </summary>
        private void mapGameToGameInstance() {
            Description = game.Description;
            ShortDescription = game.ShortDescription;
            Instructions = game.Instructions;
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
        internal static GameInstance CreateInstanceClone(GameInstance gameInstance, AppTenant appTenant, string gameInstanceName) {
            var newGameInstance = new GameInstance(appTenant, gameInstance.game, gameInstanceName) {
                Description = gameInstance.Description,
                ShortDescription = gameInstance.ShortDescription,
                Instructions = gameInstance.Instructions,
                Controls = gameInstance.Controls
            };
            return newGameInstance;
        }

        /// <summary>
        /// Sets provided argument to slug. If necessary provided argument is transformed
        /// to slug form.
        /// </summary>
        /// <param name="slugValue">Slug value</param>
        public void SetSlug(string slugValue) {
            if (String.IsNullOrWhiteSpace(slugValue)) throw new ArgumentNullException("slugValue", "Game slug must contain some value.");

            slug = slugValue.ToSlug();
        }

        /// <summary>
        /// Adds a secondary game category to game instance.
        /// </summary>
        /// <param name="secondaryCategory">Secondary game instance category</param>
        /// <returns>Self instance - this</returns>
        public GameInstance AddSecondaryCategory(GameCategory secondaryCategory) {
            if(PrimaryCategory == null) throw new InvalidOperationException("Primary category must be set in order to add a secondary game category.");
            if(secondaryCategory == null) throw new ArgumentNullException("secondaryCategory", "Secondary game secondaryCategory can't be null.");
            if (!AppTenant.Equals(secondaryCategory.AppTenant)) throw new ArgumentException("Game category application tenant must be equal as Game instance application tenant.");
            if(PrimaryCategory.Equals(secondaryCategory)) throw new ArgumentException("Secondary game secondaryCategory already exists as primapry game secondaryCategory. You can change the sescondary secondaryCategory or remove/replace primary game secondaryCategory.");
            if(secondaryCategories.Contains(secondaryCategory)) throw new ArgumentException("Secondary game secondaryCategory is already added.", "secondaryCategory");

            secondaryCategories.Add(secondaryCategory);

            return this;
        }

        /// <summary>
        /// Removes secondary game instance category
        /// </summary>
        /// <param name="secondaryCategory">Secondary game instance category to be removed</param>
        /// <returns>true if removal was successful, otherwise false</returns>
        public bool RemoveSecondaryCategory(GameCategory secondaryCategory) {
            return secondaryCategories.Remove(secondaryCategory);
        }

        /// <summary>
        /// Adds tag to game tags
        /// </summary>
        /// <param name="tag">Tag to be added</param>
        /// <returns>Self instance - this</returns>
        public GameInstance AddTag(Tag tag) {
            if (tag == null) throw new ArgumentNullException("tag");
            if (!tag.LanguageCode.Equals(appTenant.LanguageCode)) throw new ArgumentException("Tag's language code is different from application tenant language code.");

            tags.Add(tag);

            return this;
        }

        /// <summary>
        /// Removes tag from game tags
        /// </summary>
        /// <param name="tag">Tag to be removed</param>
        /// <returns>true if removal was successful, otherwise false</returns>
        public bool RemoveTag(Tag tag) {
            return tags.Remove(tag);
        }

        #endregion

    }
}
