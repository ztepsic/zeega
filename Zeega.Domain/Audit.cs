using System;
using Zed.Core.Domain;

namespace Zeega.Domain {
    /// <summary>
    /// The value object that represents Audit data
    /// </summary>
    public class Audit {

        #region Fields and Properties

        /// <summary>
        /// Creation date and time
        /// </summary>
        private readonly DateTime created;

        /// <summary>
        /// Gets creation date and time
        /// </summary>
        public DateTime Created { get { return created; } }


        /// <summary>
        /// Gets or Sets update date and time
        /// </summary>
        public DateTime Updated { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of Audit class based on creation date
        /// </summary>
        /// <param name="created">Date of creation</param>
        public Audit(DateTime created) {
            this.created = created;
            Updated = created;
        }

        #endregion

        #region Methods

        #endregion

    }
}
