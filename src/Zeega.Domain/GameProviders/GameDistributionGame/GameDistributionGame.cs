using Zed.Domain;

namespace Zeega.Domain.GameProviders.GameDistributionGame {
    public class GameDistributionGame : Entity {

        #region Fields and Properties

        private readonly int externalId;

        /// <summary>
        /// Original Game Id
        /// </summary>
        public virtual int ExternalId { get { return externalId; } }

        private readonly GamesImport gamesImport;

        public virtual GamesImport GamesImport { get { return gamesImport; } }

        private readonly string title;

        public virtual string Title { get { return title; } }

        public virtual string Description { get; set; }

        /// <summary>
        /// Category title
        /// </summary>
        public virtual string CatTitle { get; set; }

        public virtual string Tags { get; set; }

        public virtual IList<string> TagsList {
            get {
                return string.IsNullOrEmpty(Tags)
                    ? new List<string>()
                    : Tags.Split(',')
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Select(x => x.Trim().ToLower()).ToList()
                ;
            }
        }

        public virtual DateTime? ActivedDate { get; set; }

        public virtual DateTime AddedDate { get; set; }

        /// <summary>
        /// "GameAddedDate": "10.12.2017 14:39:36",
        /// </summary>
        public virtual string GameAddedDate { get; set; }

        /// <summary>
        /// External thumbnail url
        /// </summary>
        public virtual string ExternalThumbUrl { get; set; }

        public virtual string Thumbnail { get; set; }

        /// <summary>
        /// External game url
        /// </summary>
        public virtual string ExternalUrl { get; set; }

        public virtual string ExternalSrcUrl { get; set; }

        /// <summary>
        /// Provider's Web page of the game
        /// </summary>
        public virtual string LinkUrl { get; set; }

        /// <summary>
        /// Game type like Html5 or Flash
        /// </summary>
        public virtual GameDiscributionGameType GameType { get; set; }

        /// <summary>
        /// Game Width
        /// </summary>
        public virtual int? Width { get; set; }

        /// <summary>
        /// Game height
        /// </summary>
        public virtual int? Height { get; set; }

        /// <summary>
        /// Game MD5 hash
        /// </summary>
        public virtual string GameMd5 { get; set; }

        #endregion

        #region Constructors and Init

        protected GameDistributionGame() { }

        public GameDistributionGame(GamesImport gamesImport, int externalId, string title) {
            this.gamesImport = gamesImport;
            this.externalId = externalId;
            this.title = title;
        }

        #endregion

    }
}
