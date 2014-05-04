using Zeega.Domain;

namespace Zeega.Web {
    /// <summary>
    /// Application configuration
    /// </summary>
    public interface IAppConfig {

        /// <summary>
        /// Gets an indicator wheater is site/application enabled
        /// </summary>
        bool IsSiteEnabled { get; }

        /// <summary>
        /// Gets an indicator wheater are Ads on Application level enabled
        /// </summary>
        bool AreAdsEnabled { get; }

        /// <summary>
        /// Gets an application language
        /// </summary>
        string Language { get; }

        /// <summary>
        /// Gets an application title
        /// </summary>
        string AppTitle { get; }

        /// <summary>
        /// Gets application tenant code
        /// </summary>
        string AppTenantCode { get; }
        

        /// <summary>
        /// Get application tenant
        /// </summary>
        AppTenant AppTenant { get; }

    }
}
