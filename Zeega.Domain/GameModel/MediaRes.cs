using Zed.Core.Domain;
using Zed.Core.Objects;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents media resources like thubmnail, screenshots and video
    /// </summary>
    public class MediaRes {

        #region Fields and Properties

        /// <summary>
        /// Path to game's 100x100 thumbnail
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Path to game's 200x200 thumbnail
        /// </summary>
        public string ThumbnailLargeUrl { get; set; }

        /// <summary>
        /// Path to game's screenshot thumbnails 1. Clamped to 350px in width.
        /// </summary>
        public string Screenshoot1Thumbnail { get; set; }

        /// <summary>
        /// Path to game's screenshots 1. No standard size.
        /// </summary>
        public string Screenshoot1Url { get; set; }

        /// <summary>
        /// Path to game's screenshot thumbnails 2. Clamped to 350px in width.
        /// </summary>
        public string Screenshoot2Thumbnail { get; set; }

        /// <summary>
        /// Path to game's screenshots 2. No standard size.
        /// </summary>
        public string Screenshoot2Url { get; set; }

        /// <summary>
        /// Path to game's screenshot thumbnails 3. Clamped to 350px in width.
        /// </summary>
        public string Screenshoot3Thumbnail { get; set; }

        /// <summary>
        /// Path to game's screenshots 3. No standard size.
        /// </summary>
        public string Screenshoot3Url { get; set; }

        /// <summary>
        /// Path to game's screenshot thumbnails 4. Clamped to 350px in width.
        /// </summary>
        public string Screenshoot4Thumbnail { get; set; }

        /// <summary>
        /// Path to game's screenshots 4. No standard size.
        /// </summary>
        public string Screenshoot4Url { get; set; }

        /// <summary>
        /// Path to game's gameplay video. Hosted on Vimeo, YouTube or WeGame.
        /// </summary>
        public string VideoUrl { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of MediRes class with provided game thumbnail url
        /// </summary>
        /// <param name="thumbnailUrl">Game thumbnail URL</param>
        public MediaRes(string thumbnailUrl) {
            ThumbnailUrl = thumbnailUrl;
        }

        #endregion

        #region Methods

        #endregion

    }
}