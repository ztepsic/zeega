using System.ComponentModel;

namespace Zeega.Domain.GameProviders.GameDistributionGame {
    public enum GameDiscributionGameType {
        [Description("unknown")]
        Unknown = 0,
        [Description("flash")]
        Flash = 1,
        [Description("html5")]
        Html5 = 5
    }
}
