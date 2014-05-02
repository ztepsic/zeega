using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;

namespace Zeega.Web {
    /// <summary>
    /// Application configuration handler
    /// </summary>
    public class AppConfigHandler : IConfigurationSectionHandler {
        public object Create(object parent, object configContext, XmlNode section) {
            var appConfig = new AppConfig();

            var isSiteEnabledElement = section.SelectSingleNode("isSiteEnabled");
            if (isSiteEnabledElement != null) {
                appConfig.IsSiteEnabled = bool.Parse(isSiteEnabledElement.InnerText);
            }

            var areAdsEnabledElement = section.SelectSingleNode("areAdsEnabled");
            if (areAdsEnabledElement != null) {
                appConfig.AreAdsEnabled = bool.Parse(areAdsEnabledElement.InnerText);
            }

            var appTitleElement = section.SelectSingleNode("appTitle");
            if (appTitleElement != null) {
                appConfig.AppTitle = appTitleElement.InnerText;
            }

            var appTenantElement = section.SelectSingleNode("appTenant");
            if (appTenantElement != null) {
                appConfig.AppTenant = appTenantElement.InnerText;
            }

            var languageElement = section.SelectSingleNode("language");
            if (languageElement != null) {
                appConfig.Language = languageElement.InnerText;
            }

            return appConfig;
        }
    }
}