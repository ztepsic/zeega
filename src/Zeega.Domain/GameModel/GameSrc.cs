using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// GameSrc class that represents a game source
    /// </summary>
    public class GameSrc : ValueObject {

        #region Constants

        /// <summary>
        /// Minimum allowed width
        /// </summary>
        public const int MIN_WIDTH = 100;

        /// <summary>
        /// Minimum allowed height
        /// </summary>
        public const int MIN_HEIGHT = 100;

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Game width in pixels
        /// </summary>
        private readonly int width;

        /// <summary>
        /// Gets game width in pixels
        /// </summary>
        public int Width => width;

        /// <summary>
        /// Game height in pixels
        /// </summary>
        private readonly int height;

        /// <summary>
        /// Gets game height in pixels
        /// </summary>
        public int Height => height;

        /// <summary>
        /// Game source type
        /// </summary>
        private readonly GameSrcType srcType;

        /// <summary>
        /// Gets game source type
        /// </summary>
        public GameSrcType SrcType {
            get { return srcType; }
        }


        /// <summary>
        /// A game source URL
        /// </summary>
        private readonly string srcUrl;

        /// <summary>
        /// Gets a game source URL
        /// </summary>
        public string SrcUrl => srcUrl;

        /// <summary>
        /// An embed code of game source
        /// </summary>
        private readonly string embedCode;

        /// <summary>
        /// Gets an embed code of game source
        /// </summary>
        public string EmbedCode => embedCode;

        /// <summary>
        /// Information is game source embedded resource.
        /// True if it is, false otherwise
        /// </summary>
        public bool IsEmbedded => !string.IsNullOrEmpty(EmbedCode);

        /// <summary>
        /// Gets or Sets the indicator if game source is online/live (true) or offline (false)
        /// </summary>
        public bool IsSrcOnline { get; set; }

        /// <summary>
        /// Gets or sets a game source local file name
        /// </summary>
        public string SrcLocalFile { get; set; }

        /// <summary>
        /// Gets or Sets device type support
        /// </summary>
        public DeviceTypeSupport DeviceTypeSupport { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor
        /// </summary>
        private GameSrc() { }

        /// <summary>
        /// Creates resource based on provided parameters.
        /// </summary>
        /// <param name="width">Width of the game resource</param>
        /// <param name="height">Height of the game resource</param>
        /// <param name="srcType">Game source type</param>
        /// <param name="srcUrl">Game resource url</param>
        /// <param name="localFile">Game resource local file name</param>
        /// <param name="embedCode">Game resource embed code</param>
        protected GameSrc(int width, int height, GameSrcType srcType, string srcUrl = null, string localFile = null, string embedCode = null) {
            //if (width < MIN_WIDTH) { throw new ArgumentException($"Provided width is to small. Minimum allowed swf width is {MIN_WIDTH}"); }
            //if (height < MIN_HEIGHT) { throw new ArgumentException($"Provided height is to small. Minimum allowed swf height is {MIN_HEIGHT}"); }
            this.width = width;
            this.height = height;
            this.srcType = srcType;
            this.srcUrl = srcUrl;
            SrcLocalFile = localFile;
            this.embedCode = embedCode;

            if (!string.IsNullOrEmpty(srcUrl) || !string.IsNullOrEmpty(embedCode) || !string.IsNullOrEmpty(localFile)) {
                IsSrcOnline = true;
            }

        }

        /// <summary>
        /// Creates resource based on URL source
        /// </summary>
        /// <param name="width">Width of the game resource</param>
        /// <param name="height">Height of the game resource</param>
        /// <param name="srcType">Game source type</param>
        /// <param name="srcUrl">Game resource url</param>
        public static GameSrc CreateGameSrcWithUrl(int width, int height, GameSrcType srcType, string srcUrl) {
            return new GameSrc(width, height, srcType, srcUrl);
        }

        /// <summary>
        /// Creates resource based on local file source.
        /// </summary>
        /// <param name="width">Width of the game resource</param>
        /// <param name="height">Height of the game resource</param>
        /// <param name="srcType">Game source type</param>
        /// <param name="localFile">Game resource local file name</param>
        /// <param name="srcUrl">Game resource url</param>
        public static GameSrc CreateGameSrcWithLocalFile(int width, int height, GameSrcType srcType, string localFile, string srcUrl = null) {
            return new GameSrc(width, height, srcType, srcUrl, localFile);
        }

        /// <summary>
        /// Creates resource based on embed code
        /// </summary>
        /// <param name="width">Width of the game resource</param>
        /// <param name="height">Height of the game resource</param>
        /// <param name="srcType">Game source type</param>
        /// <param name="embedCode">Game resource embed code</param>
        public static GameSrc CreateGameSrcWithEmbedCode(int width, int height, GameSrcType srcType, string embedCode) {
            return new GameSrc(width, height, srcType, embedCode: embedCode);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets game source URI based on online status
        /// </summary>
        /// <returns>Game source URI</returns>
        public string GetSrcUri() {
            string srcUri;
            if (IsSrcOnline) {
                srcUri = !string.IsNullOrEmpty(EmbedCode) ? EmbedCode : SrcUrl;
            } else {
                srcUri = SrcLocalFile;
            }

            return srcUri;
        }

        #endregion

    }
}
