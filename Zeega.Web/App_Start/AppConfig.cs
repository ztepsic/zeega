using System;
using Zeega.Domain;

namespace Zeega.Web {
    /// <summary>
    /// Application configuration
    /// </summary>
    public class AppConfig : IAppConfig {

        #region Fields and Properties

        /// <summary>
        /// Gets an indicator Is site/application enabled
        /// </summary>
        public bool IsSiteEnabled { get; private set; }

        /// <summary>
        /// Gets an indicator wheater are Ads on Application level enabled
        /// </summary>
        public bool AreAdsEnabled { get; private set; }

        /// <summary>
        /// Gets an application language
        /// </summary>
        public string Language { get { return AppTenant.LanguageCode.Value; } }

        /// <summary>
        /// Gets application tenant code
        /// </summary>
        public string AppTenantCode { get { return AppTenant.Code; } }

        /// <summary>
        /// Gets an application title
        /// </summary>
        public string AppTitle { get { return AppTenant.Name; } }

        /// <summary>
        /// Application tenant
        /// </summary>
        private readonly AppTenant appTenant;

        /// <summary>
        /// Get application tenant
        /// </summary>
        public AppTenant AppTenant { get { return appTenant; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates an instance of application config
        /// </summary>
        /// <param name="appTenant">Application tenant</param>
        public AppConfig(AppTenant appTenant) {
            if (appTenant == null) throw new ArgumentNullException("appTenant", "AppTenant can't be null.");
            this.appTenant = appTenant;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Sets an indicator whether is site/application enabled
        /// </summary>
        /// <param name="isSiteEnabled">An indicator whether is site/application enabled</param>
        public void SetIsSiteEnabled(bool isSiteEnabled) { IsSiteEnabled = isSiteEnabled; }

        /// <summary>
        /// Sets an indicator whether are ads enabled
        /// </summary>
        /// <param name="areAdsEnabled">An indicator whether are ads enabled</param>
        public void SetAreAdsEnabled(bool areAdsEnabled) { AreAdsEnabled = areAdsEnabled; }

        #endregion
        
    }
}