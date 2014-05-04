using System;
using System.Web.Mvc;

namespace Zeega.Web.Controllers {
    /// <summary>
    /// Zeega base controller
    /// </summary>
    public abstract class ZeegaBaseController : Controller {

        #region Fields and Properties

        /// <summary>
        /// Application config
        /// </summary>
        private readonly IAppConfig appConfig = MvcApplication.AppConfig;

        /// <summary>
        /// Gets application config
        /// </summary>
        public IAppConfig AppConfig { get { return appConfig; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates Zeega base controller
        /// </summary>
        /// <param name="appConfig">Application configuration</param>
        protected ZeegaBaseController(IAppConfig appConfig) {
            if(appConfig == null) throw new ArgumentNullException("appConfig", "Application configuration can't be null.");
            this.appConfig = appConfig;
        }

        #endregion

    }
}