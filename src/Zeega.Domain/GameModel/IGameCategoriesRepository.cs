using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Game categories repository interface
    /// </summary>
    public interface IGameCategoriesRepository : ICrudRepository<GameCategory> {
        /// <summary>
        /// Gets game category for particular game category example
        /// </summary>
        /// <param name="gameCategory">Example to search for</param>
        /// <returns>Game category that satisfies example</returns>
        GameCategory GetByExample(GameCategory gameCategory);
    }
}
