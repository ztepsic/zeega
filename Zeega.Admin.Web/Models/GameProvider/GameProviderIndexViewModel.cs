using System.Collections.Generic;

namespace Zeega.Admin.Web.Models.GameProvider {
    public class GameProviderIndexViewModel : PageViewModel {
        public IEnumerable<GameProviderModel> GameProviders { get; set; }
    }
}