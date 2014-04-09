using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.Tests.GameModel {
    [TestFixture]
    public class GameInstanceFactoryTests {

        [Test]
        public void CreateCloneOf_ExistingGameInstance_NewGameInstanceWithCopiedValuesFromPassedGameArgument() {
            // Arrange
            var appTenant1 = new AppTenant("Zeega", new LanguageCode(LanguageCode.ENGLISH_TWO_LETTER_CODE));
            var game = new Game("Angry Birds");
            var gameInstance1 = new GameInstance(appTenant1, game);
            var baseTag1 = Tag.CreateBaseTag("TagEN1");
            var baseTag2 = Tag.CreateBaseTag("TagEN2");
            gameInstance1
                .AddTag(baseTag1)
                .AddTag(baseTag2);

            var appTenant2 = new AppTenant("OtkrijIgre", new LanguageCode(LanguageCode.CROATIAN_TWO_LETTER_CODE));
            var gameInstance2Name = "Angry Birds New Instance";

            var tag1 = Tag.CreateTag("TagHR1", appTenant2.LanguageCode, baseTag1);
            var tag2 = Tag.CreateTag("TagHR2", appTenant2.LanguageCode, baseTag2);

            var tagsRepoMock = new Mock<ITagsRepository>();
            tagsRepoMock.Setup(tagsRepo => tagsRepo.GetTagsFor(gameInstance1.Tags, appTenant2.LanguageCode))
                .Returns(new List<Tag>() { tag1, tag2 });

            var gameInstanceFactory = new GameInstanceFactory(tagsRepoMock.Object);

            // Act
            var gameInstance2 = gameInstanceFactory.CreateCloneOf(gameInstance1, appTenant2, gameInstance2Name);

            // Assert
            Assert.IsNotNull(gameInstance2);
            Assert.AreNotSame(gameInstance1, gameInstance2);
            Assert.AreNotEqual(gameInstance1, gameInstance2);
            Assert.AreEqual(appTenant2, gameInstance2.AppTenant);
            Assert.AreEqual(gameInstance2Name, gameInstance2.Name);
            Assert.AreEqual(gameInstance1.Description, gameInstance2.Description);
            Assert.AreEqual(gameInstance1.ShortDescription, gameInstance2.ShortDescription);
            Assert.AreEqual(gameInstance1.Instructions, gameInstance2.Instructions);
            Assert.AreEqual(gameInstance1.Controls, gameInstance2.Controls);
            Assert.IsTrue(gameInstance2.Tags.Count == 2);
            Assert.AreEqual(tag1, gameInstance2.Tags[0]);
            Assert.AreEqual(tag2, gameInstance2.Tags[1]);
        }

    }
}
