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
        /// Maximum number of charecters for short description
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
        /// Primary game secondaryCategory
        /// </summary>
        public GameCategory PrimaryCategory { get; set; }

        /// <summary>
        /// List of secondary game instance categories
        /// </summary>
        private readonly IList<GameCategory> secondaryCategories;

        /// <summary>
        /// Gets list of secondary game instance categories
        /// </summary>
        public IList<GameCategory> SesondaryCategories {
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
            
        }

        #endregion

        #region Methods

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
        public void AddSecondaryCategory(GameCategory secondaryCategory) {
            if(secondaryCategory == null) throw new ArgumentNullException("secondaryCategory", "Secondary game secondaryCategory can't be null.");
            if(PrimaryCategory.Equals(secondaryCategory)) throw new ArgumentException("Secondary game secondaryCategory already exists as primapry game secondaryCategory. You can change the sescondary secondaryCategory or remove/replace primary game secondaryCategory.");
            if(secondaryCategories.Contains(secondaryCategory)) throw new ArgumentException("Secondary game secondaryCategory is already added.", "secondaryCategory");

            secondaryCategories.Add(secondaryCategory);
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
        public void AddTag(Tag tag) {
            if (tag == null) throw new ArgumentNullException("tag");
            if (!tag.LanguageCode.Equals(appTenant.LanguageCode)) throw new ArgumentException("Tag's language code is different from application tenant language code.");

            tags.Add(tag);
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
