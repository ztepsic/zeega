using NUnit.Framework;
using Zeega.Domain.GameModel;
using Zed.Core.Utilities;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameCategoryTests {
        [Test]
        public void Ctor_Params_CreatedGameCategory() {
            // Arrange
            const string gameCategoryName = "Card games";

            // Act
            var gameCategory = new GameCategory(gameCategoryName);

            // Assert
            Assert.IsNotNull(gameCategory);
            Assert.AreEqual(gameCategoryName, gameCategory.Name);
            Assert.AreEqual(gameCategoryName.ToSlug(), gameCategory.Slug);
        }

    }
}
