using NHibernate;
using Zed.NHibernate;
using Zeega.Domain.GameProviders.GameDistributionGame;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameProviders {
    /// <summary>
    /// Games NHibernate repository
    /// </summary>
    public class GameDistributinGamesNhRepository : NHibernateCrudRepository<GameDistributionGame>, IGameDistributionGamesRepository {

        #region Fields and Properties
        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates game distribution games NHibernate repository
        /// </summary>
        /// <param name="sessionFactory">NHibernate session factory</param>
        public GameDistributinGamesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets latest game added date
        /// </summary>
        /// <returns>Lastest game provider added date</returns>
        public DateTime GetLatestGameAddedDate() {
            var result = (
                from game in Session.Query<GameDistributionGame>()
                select game
                );

            DateTime? resultDate = result.Max(x => (DateTime?)x.AddedDate);

            return resultDate ?? DateTime.MinValue;
        }

        /// <summary>
        /// Gets game based on gameMd5 and addedDate
        /// </summary>
        /// <param name="gameMd5">External id</param>
        /// <param name="addedDate">Provider id</param>
        /// <returns>GameDistribution entry</returns>
        public GameDistributionGame GetByMd5AndAddedDate(string gameMd5, DateTime addedDate) {
            return (
                from game in Session.Query<GameDistributionGame>()
                where game.GameMd5 == gameMd5 && game.AddedDate == addedDate
                select game
                ).FirstOrDefault();
        }

        #endregion
    }
}
