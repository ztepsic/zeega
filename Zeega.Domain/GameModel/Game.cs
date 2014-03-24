using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zed.Core.Domain;
using Zed.Core.Utilities;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents game entity
    /// </summary>
    public class Game : Entity {

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
        /// Game's name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets game's name
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Game name must contain some value.");

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
        public GameCategory Category { get; set; }

        /// <summary>
        /// Gets or Sets the full text description of the game
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Short text description of the game
        /// Includes up to 300 characters.
        /// </summary>
        private string shortDescription;

        /// <summary>
        /// Gets or Sets short text description of game.
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
        /// Gets or Sets media resources of the game
        /// like thumbnails, screenshots and video
        /// </summary>
        public MediaRes MediaRes { get; set; }

        /// <summary>
        /// Gets or Sets game source
        /// </summary>
        public GameSrc GameSrc { get; set; }

        /// <summary>
        /// List of game tags/keywords
        /// </summary>
        private readonly IList<Tag> tags;

        /// <summary>
        /// Gets list of game tags/keywords
        /// </summary>
        public IList<Tag> Tags {
            get { return new ReadOnlyCollection<Tag>(tags); }
        }

        /// <summary>
        /// A URL where the game is located (the developer's or provider's site)
        /// </summary>
        public string ProviderGameUrl { get; set; }

        /// <summary>
        /// Gets or sets flag that indicates relative path usage
        /// for media files
        /// </summary>
        public bool UseRelativePath { get; set; }

        /// <summary>
        /// Game author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Game author URL
        /// </summary>
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Game audit
        /// </summary>
        public Audit Audit { get; set; }

        /// <summary>
        /// Indicates if game is published (true) or not (false)
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Indicates if game is online/working (true) or not (false)
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Gets or Sets device type
        /// </summary>
        public DeviceType DeviceType { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of Game class with provded paramaters.
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game</param>
        /// <param name="name">Game name</param>
        public Game(AppTenant appTenant, string name) {
            if (appTenant == null) throw new ArgumentNullException("appTenant", "Application tenant can't be null.");

            this.appTenant = appTenant;
            Name = name;
            SetSlug(Name);

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
            if (String.IsNullOrWhiteSpace(slugValue)) throw new ArgumentException("Game slug must contain some value.", "slugValue");

            slug = slugValue.ToSlug();
        }

        /// <summary>
        /// Adds tag to game tags
        /// </summary>
        /// <param name="tag">Tag to be added</param>
        public void AddTag(Tag tag) {
            if(tag == null) throw new ArgumentNullException("tag");

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
