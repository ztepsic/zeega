using System.Linq;
using System.Web.Mvc;
using Zed.NHibernate.Web;
using Zeega.Domain.GameModel;
using Zeega.Web.Localization;
using Zeega.Web.Models.Nav;

namespace Zeega.Web.Controllers {
    /// <summary>
    /// Navigation controller
    /// </summary>
    public class NavController : ZeegaBaseController {

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
        /// <param name="appConfig">Application config</param>
        /// <param name="gameCategoriesRepository">Game categories repository</param>
        public NavController(IAppConfig appConfig, IGameCategoriesRepository gameCategoriesRepository) : base(appConfig) {
            this.gameCategoriesRepository = gameCategoriesRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets main navigation
        /// </summary>
        /// <returns>MainNav navigation</returns>
        [NHibernateTransaction]
        public PartialViewResult MainNav() {
            var mainNavViewModel = new MainNavViewModel {
                GameCategories = gameCategoriesRepository.GetCategoriesWithGames(AppConfig.AppTenant).ToArray()
            };
            return PartialView(mainNavViewModel);
        }

        #endregion
    }
}