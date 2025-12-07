using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel {
    /// <summary>
    /// Games NHibernate repository
    /// </summary>
    public class GamesNhRepository : NHibernateCrudRepository<Game>, IGamesRepository {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates games NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GamesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets latest game provider change date
        /// </summary>
        /// <param name="gameProviderId">Game provider</param>
        /// <returns>Lastest game provider change date</returns>
        public DateTime GetLatestGameProviderChangeDate(int gameProviderId) {
            var result = (
                from game in Session.Query<Game>()
                where game.Provider.Id == gameProviderId
                select game
                );

            DateTime? resultDate = result.Max(x => (DateTime?)x.ProviderUpdateDate);

            return resultDate ?? DateTime.MinValue;
        }

        /// <summary>
        /// Gets game based on external id for particular provider
        /// </summary>
        /// <param name="externalId">External id</param>
        /// <param name="providerId">Provider id</param>
        /// <returns>Game with external id</returns>
        public Game GetByExternalId(string externalId, int providerId) {
            return (
                from game in Session.Query<Game>()
                where game.ExternalId.Equals(externalId) && game.Provider.Id == providerId
                select game
                ).FirstOrDefault();
        }

        /// <summary>
        /// Gets games based on external ids for particular provider
        /// </summary>
        /// <param name="externalIds">List of external ids</param>
        /// <param name="providerId">Provider id</param>
        /// <returns>Games with external id</returns>
        public IEnumerable<Game> GetByExternalIds(IList<string> externalIds, int providerId) {
            return from game in Session.Query<Game>()
                   where externalIds.Contains(game.ExternalId) && game.Provider.Id == providerId
                   select game;
        }

        #endregion
    }
}
