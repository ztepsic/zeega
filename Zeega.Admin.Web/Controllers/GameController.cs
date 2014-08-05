using System;
using System.Web.Mvc;
using AutoMapper;
using Zeega.Admin.Web.Models.Game;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web.Controllers {
    /// <summary>
    /// Game management controller
    /// </summary>
    public class GameController : Controller {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            return View(new GameViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(GameViewModel gameViewModel) {
            foreach (var modelState in ModelState) {
                Console.WriteLine(modelState.Key);
            }
            if (ModelState.IsValid) {
                var game = Mapper.Map<GameViewModel, Game>(gameViewModel);
                return View(gameViewModel);    
            } else {
                return View(gameViewModel);    
            }
            
        }

    }
}