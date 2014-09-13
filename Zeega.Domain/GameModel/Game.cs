using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents game entity
    /// </summary>
    public class Game : Entity {

        #region Fields and Properties

        /// <summary>
        /// Game's name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets game's name
        /// </summary>
        public virtual string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game name must contain some value.");

                name = value;
            }
        }

        /// <summary>
        /// Gets or Sets game external/original Id
        /// </summary>
        public virtual string ExternalId { get; set; }

        /// <summary>
        /// Game categories
        /// </summary>
        private readonly IList<GameCategory> categories;

        /// <summary>
        /// Gets game categories
        /// </summary>
        public virtual IList<GameCategory> Categories { get { return new ReadOnlyCollection<GameCategory>(categories); } }

        /// <summary>
        /// Gets or Sets the full text description of the game
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or Sets short text description of game.
        /// </summary>
        public virtual string ShortDescription { get; set; }

        /// <summary>
        /// Gets or Sets game instructions
        /// </summary>
        public virtual string Instructions { get; set; }

        /// <summary>
        /// Game controls
        /// </summary>
        public virtual string Controls { get; set; }

        /// <summary>
        /// List of game tags/keywords
        /// </summary>
        private readonly IList<Tag> tags;

        /// <summary>
        /// Gets list of game  tags/keywords
        /// </summary>
        public virtual IList<Tag> Tags { get { return new ReadOnlyCollection<Tag>(tags); } }

        /// <summary>
        /// List of media resources
        /// </summary>
        private readonly IList<MediaRes> mediaResources;

        /// <summary>
        /// Gets or Sets media resources of the game
        /// like thumbnails, screenshots and video
        /// </summary>
        public virtual IList<MediaRes> MediaResources {
            get { return new ReadOnlyCollection<MediaRes>(mediaResources); }
        }

        /// <summary>
        /// Gets or Sets game source
        /// </summary>
        public virtual GameSrc GameSrc { get; set; }

        /// <summary>
        /// Game's provider
        /// </summary>
        private readonly GameProvider provider;

        /// <summary>
        /// Gets game's provider
        /// </summary>
        public virtual GameProvider Provider { get { return provider; } }

        /// <summary>
        /// A URL where the game is located (the developer's or provider's site)
        /// </summary>
        public virtual string ProviderGameUrl { get; set; }

        /// <summary>
        /// Game author
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// Game author URL
        /// </summary>
        public virtual string AuthorUrl { get; set; }

        /// <summary>
        /// URL of a zip package containing the thumb, game SWF, and meta data
        /// </summary>
        public virtual string ZipUrl { get; set; }

        /// <summary>
        /// Gets or Sets the indicator that indicates whether the zip archive was downloaded
        /// </summary>
        public virtual bool IsZipDownloaded { get; set; }

        /// <summary>
        /// Game audit
        /// </summary>
        public virtual ChangeStamp ChangeStamp { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default contructor
        /// </summary>
        protected Game() { }

        /// <summary>
        /// Creates instance of Game class with provded paramaters.
        /// </summary>
        /// <param name="name">Game name</param>
        /// <param name="provider">Game's provider</param>
        public Game(string name, GameProvider provider) {
            Name = name;

            if(provider == null) throw new ArgumentNullException("provider", "Game provider can't be undefined(null).");
            this.provider = provider;

            mediaResources = new List<MediaRes>();
            categories = new List<GameCategory>();
            tags = new List<Tag>();

            ChangeStamp = new ChangeStamp(DateTime.Now);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates and adds media resource to game source.
        /// </summary>
        /// <param name="srcUri">Media resource URI</param>
        /// <param name="srcWidth">Media resource width</param>
        /// <param name="srcHeight">Media resource height</param>
        /// <param name="type">Media resource type</param>
        public virtual MediaRes CreateMediaResource(string srcUri, int srcWidth, int srcHeight, MediaResType type) {
            var mediaRes = new MediaRes(srcUri, srcWidth, srcHeight, type) {
                Sequence = (short)(mediaResources.Count + 1)
            };
            mediaResources.Add(mediaRes);

            return mediaRes;
        }

        /// <summary>
        /// Removes media resource
        /// </summary>
        /// <param name="mediaRes">Media resource to be removed</param>
        /// <returns>true if removal was successful, otherwise false</returns>
        public virtual bool RemoveMediaResource(MediaRes mediaRes) {
            var isRemoved = mediaResources.Remove(mediaRes);

            if (isRemoved) {
                // Reorder sequence ordering
                short sequence = 0;
                foreach (var mediaResource in mediaResources) {
                    mediaResource.Sequence = ++sequence;
                }
            }

            return isRemoved;
        }

        /// <summary>
        /// Adds game category to game categories
        /// </summary>
        /// <param name="category">Game category</param>
        /// <returns>Self instance - this</returns>
        public virtual Game AddCategory(GameCategory category) {
            if(category == null) throw new ArgumentNullException("category");
            categories.Add(category);
            return this;
        }

        /// <summary>
        /// Removes game category from game categories
        /// </summary>
        /// <param name="category">Game category to be removed</param>
        /// <returns>true if removal was successful, otherwise false</returns>
        public virtual bool RemoveCategory(GameCategory category) {
            return categories.Remove(category);
        }

        /// <summary>
        /// Adds tag to game tags
        /// </summary>
        /// <param name="tag">Tag to be added</param>
        /// <returns>Self instance - this</returns>
        public virtual Game AddTag(Tag tag) {
            if (tag == null) throw new ArgumentNullException("tag");

            tags.Add(tag);

            return this;
        }

        /// <summary>
        /// Removes tag from game tags
        /// </summary>
        /// <param name="tag">Tag to be removed</param>
        /// <returns>true if removal was successful, otherwise false</returns>
        public virtual bool RemoveTag(Tag tag) {
            return tags.Remove(tag);
        }

        #endregion

    }
}
