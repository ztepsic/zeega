using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Zed.NHibernate.Web;
using Zed.Web.Models;
using Zeega.Admin.Web.Models;
using Zeega.Admin.Web.Models.GameProvider;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web.Controllers {
    /// <summary>
    /// Game provider controller
    /// </summary>
    public class GameProviderController : Controller {

        #region Fields and Properties

        /// <summary>
        /// Game providers repository
        /// </summary>
        private readonly IGameProvidersRepository gameProvidersRepository;

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates an instance of game provider contoller
        /// </summary>
        /// <param name="gameProvidersRepository">Game providers repository</param>
        public GameProviderController(IGameProvidersRepository gameProvidersRepository) {
            this.gameProvidersRepository = gameProvidersRepository;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Displays all game providers
        /// </summary>
        /// <returns>ViewResult with game providers</returns>
        [NHibernateTransaction]
        public ViewResult Index() {
            var gameProviders = gameProvidersRepository.GetAll();
            IEnumerable<GameProviderModel> gameProviderModels = Mapper.Map<IEnumerable<GameProvider>, IEnumerable<GameProviderModel>>(gameProviders);
            var gameProviderIndexViewModel = new GameProviderIndexViewModel {
                GameProviders = gameProviderModels
            };
            return View(gameProviderIndexViewModel);
        }

        /// <summary>
        /// Displays details data for requested game prvoider
        /// </summary>
        /// <param name="id">Game provider identifier</param>
        /// <returns>
        /// Page with details data for requested game provider or
        /// HttpNotFound if game provider does not exist.
        /// </returns>
        [NHibernateTransaction]
        public ActionResult Details(int id) {
            GameProvider gameProvider = gameProvidersRepository.GetById(id);
            if (gameProvider == null) { return HttpNotFound(); }

            GameProviderModel gameProviderModel = Mapper.Map<GameProviderModel>(gameProvider);
            GameProviderViewModel gameProviderViewModel = new GameProviderViewModel {
                GameProviderModel = gameProviderModel
            };

            return View(gameProviderViewModel);

        }

        /// <summary>
        /// Displays edit form page for requested game provider
        /// </summary>
        /// <param name="id">Game provider identifier</param>
        /// <returns>
        /// Page with edit form page for requested game provider or
        /// HttpNotFound if game provider does not exist.
        /// </returns>
        [NHibernateTransaction]
        public ActionResult Edit(int id) {
            GameProvider gameProvider = gameProvidersRepository.GetById(id);
            if (gameProvider == null) { return HttpNotFound(); }

            GameProviderModel gameProviderModel = Mapper.Map<GameProviderModel>(gameProvider);
            GameProviderViewModel gameProviderViewModel = new GameProviderViewModel {
                GameProviderModel = gameProviderModel
            };

            return View(gameProviderViewModel);
        }

        /// <summary>
        /// Updates game provider with submited form page data
        /// </summary>
        /// <param name="id">Game provider identifier</param>
        /// <param name="gameProviderModel">Game provider model data</param>
        /// <returns>On success redirect to details page, otherwise displays page form for creating game provider</returns>
        [NHibernateTransaction]
        [HttpPost]
        public ActionResult Edit(int id, GameProviderModel gameProviderModel) {
            GameProvider gameProvider = gameProvidersRepository.GetById(id);
            if (gameProvider == null) { return HttpNotFound(); }

            if (ModelState.IsValid) {
                gameProvider = Mapper.Map(gameProviderModel, gameProvider);
                gameProvider.ChangeStamp.SetUpdatedOn();

                gameProvidersRepository.SaveOrUpdate(gameProvider);

                TempData["message"] = string.Format("Game provider {0} has been edited.", gameProviderModel.Name);
                return RedirectToAction("Details", new { id = gameProvider.Id, slug = gameProviderModel.Slug });
            } else {
                GameProviderViewModel gameProviderViewModel = new GameProviderViewModel {
                    GameProviderModel = gameProviderModel
                };
                return View(gameProviderViewModel);
            }
        }



        /// <summary>
        /// Displays page form for creating game provider
        /// </summary>
        /// <returns>Page for creating game provider</returns>
        public ViewResult Create() {
            GameProviderViewModel gameProviderViewModel = new GameProviderViewModel {
                GameProviderModel = new GameProviderModel() { IsActive = true }
            };
            return View(gameProviderViewModel);
        }

        /// <summary>
        /// Creates a new game provider based on form data
        /// </summary>
        /// <returns>On success redirect to details page, otherwise displays page form for creating game provider</returns>
        [NHibernateTransaction]
        [HttpPost]
        public ActionResult Create(GameProviderModel gameProviderModel) {
            if (ModelState.IsValid) {
                GameProvider gameProvider = Mapper.Map<GameProvider>(gameProviderModel);
                gameProvidersRepository.SaveOrUpdate(gameProvider);

                TempData["message"] = string.Format("Game provider {0} has been created.", gameProviderModel.Name);
                return RedirectToAction("Details", new { id = gameProvider.Id, slug = gameProviderModel.Slug });
            } else {
                GameProviderViewModel gameProviderViewModel = new GameProviderViewModel {
                    GameProviderModel = gameProviderModel
                };
                return View(gameProviderViewModel);
            }
        }

        #endregion

    }
}