namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents Mochi game entity
    /// </summary>
    class MochiGame {

        #region Fields and Properties

        #region ToDo

        /// <summary>
        /// Value of true or false indicating if this game is featured by Mochi staff.
        /// </summary>
        public bool IsRecommended { get; set; }
        public string Recommendation { get; set; }

        public string Popularity { get; set; }
        public string Metascore { get; set; }

        /// <summary>
        /// TODO - create enum
        /// Content rating: all, everyone, teen, mature
        /// </summary>
        public string Rating { get; set; }
        public string Languages { get; set; }

        /// <summary>
        /// If game is tagged with Stage3D, value will be true, otherwiese it will be false.
        /// Stage3D is a full hardware-accelerated video pipeline that delivers best-in-class video playback across platforms.
        /// </summary>
        public bool IsStage3D { get; set; }

        #endregion

        // game_tag
        /// <summary>
        /// Unique 16 character key identifying this game in the Mochi system
        /// </summary>
        public string GameKey { get; set; }

        /// <summary>
        /// True or False value if the game uses MochiCoins
        /// </summary>
        public bool AreCoinsEnabled { get; set; }

        /// <summary>
        /// True or False value if the game uses MochiCoins and the developer has opted to share coins revenue with publishers
        /// </summary>
        public bool AreCoinsRevshareEnabled { get; set; }

        /// <summary>
        /// True or False value if the game uses Mochi Achievements
        /// </summary>
        public bool AreAchievementsEnabled { get; set; }

        /// <summary>
        /// True or False value if the game uses Mochi Scores
        /// </summary>
        public bool IsLeaderboardEnabled { get; set; }

        /// <summary>
        /// URL of a zip package containing the thumb, game SWF, and meta data
        /// </summary>
        public string ZipUrl { get; set; }

        /// <summary>
        /// Gets or Sets the indicator that indicates whether the zip archive was downloaded
        /// </summary>
        public bool IsZipDownloaded { get; set; }

        #endregion

        #region Constructors and Init
        #endregion

        #region Methods
        #endregion

    }
}
