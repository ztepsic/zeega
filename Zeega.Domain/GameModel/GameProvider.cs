using System;
using Zed.Domain;

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
        /// Gets or Sets game provider's official URL
        /// </summary>
        public virtual string OfficialUrl {
            get { return officialUrl; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game provider's official url must contain some value.");

                officialUrl = value;
            }
        }

        /// <summary>
        /// Gets or Sets game provider's publisher URL
        /// </summary>
        public virtual string PublisherUrl { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has publisher API
        /// </summary>
        public virtual bool HasPublisherApi { get; set; }

        /// <summary>
        /// Gets or Sets game provider's catalog URL
        /// </summary>
        public virtual string GamesCatalogUrl { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has xml game feed
        /// </summary>
        public virtual bool HasXmlFeed { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has json game feed
        /// </summary>
        public virtual bool HasJsonFeed { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider is active
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets ChangeStamp
        /// </summary>
        public virtual ChangeStamp ChangeStamp { get; set; }


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

            ChangeStamp = new ChangeStamp(DateTime.Now);
        }

        #endregion

        #region Methods

        #endregion

    }
}
