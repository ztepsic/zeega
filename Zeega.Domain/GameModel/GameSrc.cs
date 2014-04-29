using System;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// GameSrc class that represents a game source
    /// </summary>
    public class GameSrc {

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
        public int Width { get { return width; } }


        /// <summary>
        /// Game height in pixels
        /// </summary>
        private readonly int height;

        /// <summary>
        /// Gets game height in pixels
        /// </summary>
        public int Height { get { return height; } }


        /// <summary>
        /// A game source URI
        /// </summary>
        private readonly string srcUri;

        /// <summary>
        /// Gets a game source URI
        /// </summary>
        public string SrcUri { get { return srcUri; } }

        /// <summary>
        /// Gets or Sets the indicator if game source is online/live (true) or offline (false)
        /// </summary>
        public bool IsSrcOnline { get; set; }

        /// <summary>
        /// Gets or Sets device type support
        /// </summary>
        public DeviceTypeSupport DeviceTypeSupport { get; set; }

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
        /// Gets or Sets Audit
        /// </summary>
        public Audit Audit { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor
        /// </summary>
        private GameSrc() { }

        /// <summary>
        /// Creates swf resource based on provided parameters.
        /// </summary>
        /// <param name="width">Width of the swf resource</param>
        /// <param name="height">Height of the swf resource</param>
        /// <param name="srcUri">Game resource uri</param>
        /// <param name="srcType">Game source type</param>
        public GameSrc(int width, int height, string srcUri, GameSrcType srcType) {
            if (width < MIN_WIDTH) { throw new ArgumentException(String.Format("Provided width is to small. Minimum allowed swf width is {0}", MIN_WIDTH)); }
            if (height < MIN_HEIGHT) { throw new ArgumentException(String.Format("Provided height is to small. Minimum allowed swf height is {0}", MIN_HEIGHT)); }
            this.width = width;
            this.height = height;
            this.srcUri = srcUri;
            this.srcType = srcType;

            IsSrcOnline = true;
        }

        #endregion

        #region Methods

        #endregion

    }
}
