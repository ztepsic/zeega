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
        private readonly DateTime createdOn;

        /// <summary>
        /// Gets creation date and time
        /// </summary>
        public DateTime CreatedOn { get { return createdOn; } }


        /// <summary>
        /// Gets or Sets update date and time
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Audit() { }

        /// <summary>
        /// Creates instance of Audit class based on creation date
        /// </summary>
        /// <param name="createdOn">Date of creation</param>
        public Audit(DateTime createdOn) {
            this.createdOn = createdOn;
            UpdatedOn = createdOn;
        }

        #endregion

        #region Methods

        #endregion

    }
}
