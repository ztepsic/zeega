using System;
using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents media resources like thubmnail, screenshots and video.
    /// </summary>
    public class MediaRes : Entity {

        #region Constants

        /// <summary>
        /// Default order sequence
        /// </summary>
        public const short DEFAULT_ORDER_SEQUENCE = 1;

        /// <summary>
        /// Min width in pixels
        /// </summary>
        public const int MIN_WIDTH = 50;

        /// <summary>
        /// Min height in pixels
        /// </summary>
        public const int MIN_HEIGHT = 50;

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Media resource type
        /// </summary>
        private readonly MediaResType type;

        /// <summary>
        /// Gets media resource type
        /// </summary>
        public virtual MediaResType Type { get { return type; } }

        /// <summary>
        /// Thumbnail of media resource URI
        /// </summary>
        private string thumbSrcUri;

        /// <summary>
        /// Gets thubmnail of media resource URI
        /// </summary>
        public virtual string ThumbSrcUri {
            get { return thumbSrcUri; }
            set {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value", "Thumbnail of media resource URI can't be null or emtpy.");
                if(srcUri.Equals(value) && type == MediaResType.Video) throw new ArgumentException("Thmubnail URI can't be equal to media resource URI in the case of Video type.");
                thumbSrcUri = value;
            }
        }

        /// <summary>
        /// Thumbnail of media resource width in pixels
        /// </summary>
        private int thumbSrcWidth;

        /// <summary>
        /// Gets thumbnail of media resource width in pixels
        /// </summary>
        public virtual int ThumbSrcWidth {
            get { return thumbSrcWidth; }
            set {
                if (value < MIN_WIDTH) throw new ArgumentException(String.Format("Thumbnail of media resource width must be greater or equal to {0} px.", MIN_WIDTH), "value");
                thumbSrcWidth = value;
            }
        }

        /// <summary>
        /// Thumbnail media resource height in pixels
        /// </summary>
        private int thumbSrcHeight;

        /// <summary>
        /// Gets thumbnail media resource height in pixels
        /// </summary>
        public virtual int ThumbSrcHeight {
            get { return thumbSrcHeight; }
            set {
                if (value < MIN_HEIGHT) throw new ArgumentException(String.Format("Media resource height must be greater or equal to {0} px.", MIN_HEIGHT), "value");
                thumbSrcHeight = value;
            }
        }

        /// <summary>
        /// Media resource URI
        /// </summary>
        private readonly string srcUri;

        /// <summary>
        /// Gets media resource URI
        /// </summary>
        public virtual string SrcUri { get { return srcUri; } }

        /// <summary>
        /// Media resource width in pixels
        /// </summary>
        private readonly int srcWidth;

        /// <summary>
        /// Gets media resource width in pixels
        /// </summary>
        public virtual int SrcWidth { get { return srcWidth; } }

        /// <summary>
        /// Media resource height in pixels
        /// </summary>
        private readonly int srcHeight;

        /// <summary>
        /// Gets media resource height in pixels
        /// </summary>
        public virtual int SrcHeight { get { return srcHeight; } }

        /// <summary>
        /// MediaRes order sequence
        /// </summary>
        public virtual short Sequence { get; set; }

        /// <summary>
        /// Gets or Sets indicator which indicate is media resource active
        /// </summary>
        public virtual bool IsActive { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default contructor
        /// </summary>
        protected MediaRes() { }

        /// <summary>
        /// Creates instance of MediRes class with provided paremeters whare
        /// sequence order is set to default value.
        /// </summary>
        /// <param name="srcUri">Media resource URI</param>
        /// <param name="srcWidth">Media resource width</param>
        /// /// <param name="srcHeight">Media resource height</param>
        /// <param name="type">Media resource type</param>
        internal MediaRes(string srcUri, int srcWidth, int srcHeight, MediaResType type) {
            if(string.IsNullOrEmpty(srcUri)) throw new ArgumentNullException("srcUri", "Media resource URI can't be null or emtpy.");
            this.srcUri = srcUri;

            if(srcWidth < MIN_WIDTH) throw new ArgumentException(String.Format("Media resource width must be greater or equal to {0} px.", MIN_WIDTH), "srcWidth");
            this.srcWidth = srcWidth;

            if (srcHeight < MIN_HEIGHT) throw new ArgumentException(String.Format("Media resource height must be greater or equal to {0} px.", MIN_HEIGHT), "srcHeight");
            this.srcHeight = srcHeight;

            this.type = type;

            Sequence = DEFAULT_ORDER_SEQUENCE;
        }

        #endregion

        #region Methods

        #endregion

    }
}