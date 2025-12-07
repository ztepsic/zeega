using System.ComponentModel;

namespace Zeega.Infrastructure.GameProviders.GameDistribution {
    public enum GameDistributionFeedFormatType {
        [Description("xml")]
        Xml,
        [Description("json")]
        Json
    }
}
