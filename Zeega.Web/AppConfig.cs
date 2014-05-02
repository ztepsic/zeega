using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;

namespace Zeega.Web {
    /// <summary>
    /// Application configuration
    /// </summary>
    public class AppConfig {

        #region Fields and Properties

        /// <summary>
        /// Is site/application enabled
        /// TODO
        /// </summary>
        public bool IsSiteEnabled { get; set; }

        /// <summary>
        /// Are Ads on Application level enabled
        /// TODO - see what with this property
        /// </summary>
        public bool AreAdsEnabled { get; set; }

        /// <summary>
        /// Application language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Application tenant
        /// </summary>
        public string AppTenant { get; set; }

        /// <summary>
        /// Application tenant
        /// </summary>
        public string AppTitle { get; set; }

        #endregion

        #region Constructors and Init
        #endregion

        #region Methods
        #endregion

    }
}