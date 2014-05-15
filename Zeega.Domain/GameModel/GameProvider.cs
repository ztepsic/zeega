using System;
using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Entity class that represents game provider
    /// </summary>
    public class GameProvider : Entity {

        #region Fields and Properties

        /// <summary>
        /// Provider name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets game provider's name
        /// </summary>
        public virtual string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game provider's name must contain some value.");

                name = value;
            }
        }

        /// <summary>
        /// Game provider's official url
        /// </summary>
        private string officialUrl;

        /// <summary>
        /// Gets or Sets game provider's official url
        /// </summary>
        public virtual string OfficialUrl {
            get { return officialUrl; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game provider's official url must contain some value.");

                officialUrl = value;
            }
        }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default contructor
        /// </summary>
        protected GameProvider() { }

        /// <summary>
        /// Creates an instance of GameProvider by providing game provider's name
        /// </summary>
        /// <param name="name">Game provider's name</param>
        public GameProvider(string name) {
            Name = name;
        }

        #endregion

        #region Methods

        #endregion

    }
}
