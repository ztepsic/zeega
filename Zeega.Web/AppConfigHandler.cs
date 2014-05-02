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

            var appTitleElement = section.SelectSingleNode("appTitle");
            if (appTitleElement != null) {
                appConfig.AppTitle = appTitleElement.InnerText;
            }


            return appConfig;
        }
    }
}