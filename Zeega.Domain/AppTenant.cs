using System;
using Zed.Core.Domain;

namespace Zeega.Domain {
    /// <summary>
    /// Represents application's tenant in multitenant environement
    /// </summary>
    class AppTenant : Entity {

        #region Fields and Properties

        /// <summary>
        /// Application tenant name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets application tenant name
        /// </summary>
        public virtual string Name {
            get { return name; }
            set {
                if (value == null) throw new ArgumentNullException();

                name = value;
            }
        }

        /// <summary>
        /// Gets or Sets application tenant description
        /// </summary>
        public virtual string Description { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates a new instance of AppTenant class for the specified tenant name
        /// </summary>
        /// <param name="name">Tenant name</param>
        public AppTenant(string name) {
            Name = name;
        }

        #endregion

        #region Methods

        #endregion

    }
}
