using NHibernate;
using NHibernate.Criterion;
using Zed.NHibernate;
using Zeega.Domain.GameModel;

namespace Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel {
    public class GameCategoriesNhRepository : NHibernateCrudRepository<GameCategory>, IGameCategoriesRepository {

        #region Constructors and Init

        public GameCategoriesNhRepository(ISessionFactory sessionFactory) : base(sessionFactory) {}

        #endregion

        #region Methods

        /// <summary>
        /// Gets game category for particular game category example
        /// </summary>
        /// <param name="gameCategory">Example to search for</param>
        /// <returns>Game category that satisfies example</returns>
        public GameCategory GetByExample(GameCategory gameCategory) {
            var criteria = Session.CreateCriteria<GameCategory>();
            criteria.Add(Example.Create(gameCategory));
            criteria.SetMaxResults(1);
            return criteria.UniqueResult<GameCategory>();
        }

        #endregion

    }
}
