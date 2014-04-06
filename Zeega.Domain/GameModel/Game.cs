using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zed.Core.Domain;

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
        public string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game name must contain some value.");

                name = value;
            }
        }

        /// <summary>
        /// Gets or Sets game external/original Id
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Game categories
        /// </summary>
        public string Categories { get; set; }

        /// <summary>
        /// Gets or Sets the full text description of the game
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets short text description of game.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or Sets game instructions
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Game controls
        /// </summary>
        public string Controls { get; set; }

        /// <summary>
        /// Gets list of game tags/keywords
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// List of media resources
        /// </summary>
        private readonly IList<MediaRes> mediaResources;

        /// <summary>
        /// Gets or Sets media resources of the game
        /// like thumbnails, screenshots and video
        /// </summary>
        public IList<MediaRes> MediaResources {
            get { return new ReadOnlyCollection<MediaRes>(mediaResources); }
        }

        /// <summary>
        /// Gets or Sets game source
        /// </summary>
        public GameSrc GameSrc { get; set; }

        /// <summary>
        /// Game's provider
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Game's provider URL
        /// </summary>
        public string ProviderUrl { get; set; }

        /// <summary>
        /// A URL where the game is located (the developer's or provider's site)
        /// </summary>
        public string ProviderGameUrl { get; set; }

        /// <summary>
        /// Game author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Game author URL
        /// </summary>
        public string AuthorUrl { get; set; }

        /// <summary>
        /// URL of a zip package containing the thumb, game SWF, and meta data
        /// </summary>
        public string ZipUrl { get; set; }

        /// <summary>
        /// Gets or Sets the indicator that indicates whether the zip archive was downloaded
        /// </summary>
        public bool IsZipDownloaded { get; set; }

        /// <summary>
        /// Game audit
        /// </summary>
        public Audit Audit { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of Game class with provded paramaters.
        /// </summary>
        /// <param name="name">Game name</param>
        public Game(string name) {
            Name = name;

            mediaResources = new List<MediaRes>();
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
        public MediaRes CreateMediaResource(string srcUri, int srcWidth, int srcHeight, MediaResType type) {
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
        public bool RemoveMediaResource(MediaRes mediaRes) {
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

        #endregion

    }
}
