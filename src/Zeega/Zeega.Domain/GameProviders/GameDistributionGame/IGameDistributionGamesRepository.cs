using Zed.Domain;

namespace Zeega.Domain.GameProviders.GameDistributionGame {
    /// <summary>
    /// Games Distribution games repository interface
    /// </summary>
    public interface IGameDistributionGamesRepository : ICrudRepository<GameDistributionGame> {

        /// <summary>
        /// Gets latest game added date
        /// </summary>
        /// <returns>Lastest game provider added date</returns>
        DateTime GetLatestGameAddedDate();

        /// <summary>
        /// Gets game based on gameMd5 and addedDate
        /// </summary>
        /// <param name="gameMd5">External id</param>
        /// <param name="addedDate">Provider id</param>
        /// <returns>GameDistribution entry</returns>
        GameDistributionGame GetByMd5AndAddedDate(string gameMd5, DateTime addedDate);

    }
}
