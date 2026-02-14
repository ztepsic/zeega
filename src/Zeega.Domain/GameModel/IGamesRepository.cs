using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Games repository interface
    /// </summary>
    public interface IGamesRepository : ICrudRepository<Game> {
        /// <summary>
        /// Gets latest game provider change date
        /// </summary>
        /// <param name="gameProviderId">Game provider</param>
        /// <returns>Lastest game provider change date</returns>
        DateTime GetLatestGameProviderChangeDate(int gameProviderId);

        /// <summary>
        /// Gets game based on external id for particular provider
        /// </summary>
        /// <param name="externalId">External id</param>
        /// <param name="providerId">Provider id</param>
        /// <returns>Game with external id</returns>
        Game GetByExternalId(string externalId, int providerId);

        /// <summary>
        /// Gets games based on external ids for particular provider
        /// </summary>
        /// <param name="externalIds">List of external ids</param>
        /// <param name="providerId">Provider id</param>
        /// <returns>Games with external id</returns>
        IEnumerable<Game> GetByExternalIds(IList<string> externalIds, int providerId);

    }
}
