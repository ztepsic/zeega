using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Zed.Core.Domain;
using Zeega.Admin.Web.Controllers;
using Zeega.Admin.Web.Models.GameProvider;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web.Tests.Controllers {

    [TestFixture]
    public class GameProviderControllerTests {

        #region Fields and Properties

        private Mock<IGameProvidersRepository> mockGameProvidersRepo;
        private GameProviderController gameProviderController;

        #endregion

        #region Setups

        [TestFixtureSetUp]
        public void TestFixtureSetUp() {
            AutoMapperConfig.Configure();
        }

        [SetUp]
        public void SetUp() {
            mockGameProvidersRepo = new Mock<IGameProvidersRepository>();
            gameProviderController = new GameProviderController(mockGameProvidersRepo.Object);
        }

        #endregion

        #region Tests

        [Test]
        public void Index_GetGameProviders_FetchedGameProviders() {
            // Arrange
            Mock<IGameProvidersRepository> mockGameProvidersMock = new Mock<IGameProvidersRepository>();
            GameProvider[] gameProviders = new[] {
                new GameProvider("Spil Games"),
                new GameProvider("Clay.io"),
            };

            mockGameProvidersMock.Setup(x => x.GetAll()).Returns(gameProviders);

            GameProviderController gameProviderController = new GameProviderController(mockGameProvidersMock.Object);

            // Act
            ViewResult result = gameProviderController.Index();

            // Assert
            GameProviderModel[] gameProviderModels = (result.Model as IEnumerable<GameProviderModel>).ToArray();
            Assert.IsTrue(gameProviderModels.Length == gameProviders.Length);
            Assert.AreEqual(gameProviders[0].Name, gameProviderModels[0].Name);
            Assert.AreEqual(gameProviders[1].Name, gameProviderModels[1].Name);
        }

        [Test]
        public void Details_NotExistingGameProvider_HttpNotFound() {
            // Arrange
            int id = -99;

            // Act
            HttpNotFoundResult result = gameProviderController.Details(id) as HttpNotFoundResult;

            // Assert
            mockGameProvidersRepo.Verify(x => x.GetById(It.IsAny<Int32>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Details_ExistingGameProvider_GameProviderDetails() {
            // Arrange
            var gameProvider = new GameProvider("Spil Games");
            gameProvider.SetIdTo(1);
            mockGameProvidersRepo.Setup(x => x.GetById(gameProvider.Id))
                .Returns(gameProvider);

            // Act
            var result = gameProviderController.Details(gameProvider.Id) as ViewResult;

            // Assert
            mockGameProvidersRepo.Verify(x => x.GetById(gameProvider.Id), Times.Once);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOf<GameProviderModel>(result.Model);

            var gameProviderModel = result.Model as GameProviderModel;
            Assert.AreEqual(gameProvider.Id, gameProviderModel.Id);
            Assert.AreEqual(gameProvider.Name, gameProviderModel.Name);
        }

        [Test]
        public void Edit_NotExistingGameProvider_HttpNotFound() {
            // Arrange
            int id = -99;

            // Act
            HttpNotFoundResult result = gameProviderController.Edit(id) as HttpNotFoundResult;

            // Assert
            mockGameProvidersRepo.Verify(x => x.GetById(It.IsAny<Int32>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Edit_SaveValidGameProvider_RedirectedToDetails() {
            // Arrange
            const int id = 1;
            var gameProvider = new GameProvider("Spil Games") {
                OfficialUrl = "http://www.spilgames.com"
            };
            gameProvider.SetIdTo(id);
            mockGameProvidersRepo.Setup(x => x.GetById(gameProvider.Id))
                .Returns(gameProvider);

            GameProviderModel gameProviderModel = Mapper.Map<GameProviderModel>(gameProvider);
            gameProviderModel.Name = "New name";
            gameProviderModel.Id = 33;

            // Act
            RedirectToRouteResult result = gameProviderController.Edit(gameProvider.Id, gameProviderModel) as RedirectToRouteResult;

            // Assert
            // check that the repository was called
            mockGameProvidersRepo.Verify(x => x.GetById(gameProvider.Id), Times.Once);
            mockGameProvidersRepo.Verify(x => x.SaveOrUpdate(gameProvider), Times.Once);

            // check the result type
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.AreEqual("Details", result.RouteValues["action"]);
            Assert.AreEqual(id, gameProvider.Id);
            Assert.AreEqual("New name", gameProvider.Name);

        }

        [Test]
        public void Edit_SaveInvalidGameProvider_DisplayedEditForm() {
            // Arrange
            var gameProvider = new GameProvider("Spil Games") {
                OfficialUrl = "http://www.spilgames.com"
            };
            gameProvider.SetIdTo(1);
            mockGameProvidersRepo.Setup(x => x.GetById(gameProvider.Id))
                .Returns(gameProvider);

            GameProviderModel gameProviderModel = Mapper.Map<GameProviderModel>(gameProvider);
            gameProviderModel.Name = null;

            // add an error to model state
            gameProviderController.ModelState.AddModelError("error", "error");

            // Act
            ViewResult result = gameProviderController.Edit(gameProvider.Id, gameProviderModel) as ViewResult;

            // Assert
            // check that the repository was called
            mockGameProvidersRepo.Verify(x => x.GetById(gameProvider.Id), Times.Once);
            mockGameProvidersRepo.Verify(x => x.SaveOrUpdate(gameProvider), Times.Never);

            // check the result type
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(gameProviderModel, result.Model);
        }

        [Test]
        public void Create_SaveValidGameProvider_RedirectedToDetails() {
            // Arrange
            GameProviderModel gameProviderModel = new GameProviderModel {
                Name = "Spil Games",
                OfficialUrl = "http://www.spilgames.com"
            };

            // Act
            RedirectToRouteResult result = gameProviderController.Create(gameProviderModel) as RedirectToRouteResult;

            // Assert
            // check that the repository was called
            mockGameProvidersRepo.Verify(x => x.SaveOrUpdate(It.IsAny<GameProvider>()), Times.Once);

            // check the result type
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.AreEqual("Details", result.RouteValues["action"]);
            
        }

        [Test]
        public void Create_SaveInvalidGameProvider_DisplayedCreateForm() {
            // Arrange
            
            // add an error to model state
            gameProviderController.ModelState.AddModelError("error", "error");

            GameProviderModel gameProviderModel = new GameProviderModel {
                Name = "Spil Games",
                OfficialUrl = "http://www.spilgames.com"
            };

            // Act - try to save game provider
            ViewResult result = gameProviderController.Create(gameProviderModel) as ViewResult;

            // Assert
            // check that repository was not called
            mockGameProvidersRepo.Verify(x => x.SaveOrUpdate(It.IsAny<GameProvider>()), Times.Never);

            // check the result type
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(gameProviderModel, result.Model);

        }

        #endregion

    }
}
