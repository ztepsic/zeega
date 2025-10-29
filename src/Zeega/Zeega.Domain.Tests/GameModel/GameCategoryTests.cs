using NUnit.Framework;
using Zeega.Domain.GameModel;
using Zed.Utilities;

namespace Zeega.Domain.Tests.GameModel
{
    [TestFixture]
    public class GameCategoryTests
    {
        [Test]
        public void Ctor_Params_CreatedGameCategory()
        {
            // Arrange
            const string gameCategoryName = "Card games";

            // Act
            var gameCategory = new GameCategory(gameCategoryName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(gameCategory, Is.Not.Null);
                Assert.That(gameCategory.Name, Is.EqualTo(gameCategoryName));
                Assert.That(gameCategory.Slug, Is.EqualTo(gameCategoryName.ToSlug()));
            });
        }

    }
}
