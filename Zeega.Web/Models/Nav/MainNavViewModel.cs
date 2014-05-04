using System.Collections.Generic;
using Zeega.Domain.GameModel;

namespace Zeega.Web.Models.Nav {
    /// <summary>
    /// Main navigation view model
    /// </summary>
    public class MainNavViewModel {

        /// <summary>
        /// Gets or Sets game categories
        /// </summary>
        public IEnumerable<GameCategory> GameCategories { get; set; }

    }
}