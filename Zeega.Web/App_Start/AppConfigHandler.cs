using System;
using System.Configuration;
using System.Xml;
using Zed.Core.Domain;
using Zeega.Domain;

namespace Zeega.Web {
    /// <summary>
    /// Application configuration handler
    /// </summary>
    public class AppConfigHandler : IConfigurationSectionHandler {
        /// <summary>
        /// Creates application config instance form xml
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns>Application config instance</returns>
        public object Create(object parent, object configContext, XmlNode section) {
            string appTenantCode = null;
            var appTenantElement = section.SelectSingleNode("appTenant");
            if (appTenantElement != null) {
                appTenantCode = appTenantElement.InnerText;
            }

            var appTenant = createAppTenant(appTenantCode);
            var appConfig = new AppConfig(appTenant);

            var isSiteEnabledElement = section.SelectSingleNode("isSiteEnabled");
            if (isSiteEnabledElement != null) { appConfig.SetIsSiteEnabled(bool.Parse(isSiteEnabledElement.InnerText)); }

            var areAdsEnabledElement = section.SelectSingleNode("areAdsEnabled");
            if (areAdsEnabledElement != null) { appConfig.SetAreAdsEnabled(bool.Parse(areAdsEnabledElement.InnerText)); }

            // ignored
            //var appTitleElement = section.SelectSingleNode("appTitle");
            //if (appTitleElement != null) { appConfig.AppTitle = appTitleElement.InnerText; }

            // ignored
            //var languageElement = section.SelectSingleNode("language");
            //if (languageElement != null) { appConfig.Language = languageElement.InnerText; }

            return appConfig;
        }

        /// <summary>
        /// Creates application tenant instance base on application tenant code
        /// </summary>
        /// <param name="appTenantCode">Application tenant code</param>
        /// <returns>Application tenant</returns>
        private static AppTenant createAppTenant(string appTenantCode) {
            AppTenant appTenant = null;
            appTenantCode = appTenantCode.ToLower();
            if (appTenantCode.Equals("zeega")) {
                appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE), true);
                appTenant.SetIdTo(1);
            } else if (appTenantCode.Equals("otkrij-igre")) {
                appTenant = new AppTenant("Otkrij igre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE), true);
                appTenant.SetIdTo(2);
            } else {
                throw new ArgumentException("AppTenantName is unknown", "appTenantCode");
            }

            return appTenant;

        }

    }
}