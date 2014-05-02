using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Configuration;
using System.Web.Mvc;
using Zed.Core.Domain;
using Zed.NHibernate.Web;
using Zeega.Domain;
using Zeega.Domain.GameModel;
using Zeega.Web.Localization;

namespace Zeega.Web.Controllers {
    /// <summary>
    /// Navigation controller
    /// </summary>
    public class NavController : Controller {

        #region Fields and Properties

        /// <summary>
        /// Game categories repository
        /// </summary>
        private readonly IGameCategoriesRepository gameCategoriesRepository;

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates a NavController instance
        /// </summary>
        /// <param name="gameCategoriesRepository">Game categories repository</param>
        public NavController(IGameCategoriesRepository gameCategoriesRepository) {
            this.gameCategoriesRepository = gameCategoriesRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets main navigation
        /// </summary>
        /// <returns>Main navigation</returns>
        [NHibernateTransaction]
        public PartialViewResult Main() {
            var appConfig = WebConfigurationManager.GetSection("appConfig") as AppConfig;
            ViewBag.AppTitle = appConfig.AppTitle + Resource.Games;

            var appTenant = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            appTenant.SetIdTo(1);
            var returnString = String.Empty;
            //var result = gameCategoriesRepository.GetCategoriesWithGames(appTenant).Aggregate(returnString, (current, next) => current + next.Name);
            var result = gameCategoriesRepository.GetAll();
            return PartialView(result);
        }

        #endregion
    }
}