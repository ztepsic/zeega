namespace Zeega.Infrastructure.GameProviders.GameDistribution {
    public interface IGameDistributionProvider {
        Task<IEnumerable<GameDistributionGame>> FetchGamesFeedCombinedAsync(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1);
        IEnumerable<GameDistributionGame> FetchGamesFeedCombined(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1);

        /// <summary>
        /// https://games.gamedistribution.com/All/?category=All&Type=All&limit=10&offset=1&format=json
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GameDistributionGame>> FetchGamesFeedAsync(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1, GameDistributionFeedFormatType formatType = GameDistributionFeedFormatType.Xml);

        /// <summary>
        /// Gets a list of all shows in the TvMaze database andthe timestap when they
        /// were last updated.
        /// </summary>
        /// <returns>List of all updated shows</returns>
        IEnumerable<GameDistributionGame> FetchGamesFeed(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1, GameDistributionFeedFormatType formatType = GameDistributionFeedFormatType.Xml);
    }
}