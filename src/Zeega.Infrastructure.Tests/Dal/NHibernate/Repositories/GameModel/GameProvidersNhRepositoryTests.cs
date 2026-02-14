using Zeega.Domain.GameModel;
using Zeega.Infrastructure.Dal.NHibernate.Repositories.GameModel;

namespace Zeega.Infrastructure.Tests.Dal.NHibernate.Repositories.GameModel;

[TestFixture]
public class GameProvidersNhRepositoryTests : SQLiteNHibernateTestFixture {

    [Test]
    public void SaveOrUpdate_GameProvider_AddedToDb() {
        // Arrange
        var gameProvider = new GameProvider("Spil Games") {
            OfficialUrl = "http://www.spilgames.com"
        };

        var gameProvidersRepo = new GameProvidersNhRepository(SessionFactory);

        // Act
        using (var trx = Session.BeginTransaction()) {
            gameProvidersRepo.SaveOrUpdate(gameProvider);
            trx.Commit();
        }


        // Assert
    }

    [Test]
    public void Get_GameProvider_FetchedGameProvider() {
        // Arrange
        var gameProvider = new GameProvider("Spil Games") {
            OfficialUrl = "http://www.spilgames.com"
        };

        var gameProvidersRepo = new GameProvidersNhRepository(SessionFactory);

        using (var trx = Session.BeginTransaction()) {
            gameProvidersRepo.SaveOrUpdate(gameProvider);
            trx.Commit();
        }

        Session.Clear(); // To clear cache so we can see select

        // Act
        GameProvider fetchedGameProvider = null;
        using (var trx = Session.BeginTransaction()) {
            fetchedGameProvider = gameProvidersRepo.GetById(gameProvider.Id);
            trx.Commit();
        }

        // Assert
        Assert.That(fetchedGameProvider, Is.Not.Null);
        Assert.That(fetchedGameProvider, Is.EqualTo(gameProvider));
    }


    [Test]
    public void Get_GameProvider_ChangeStampInUtcKind() {
        // Arrange
        var gameProvider = new GameProvider("Spil Games") {
            OfficialUrl = "http://www.spilgames.com"
        };

        var gameProvidersRepo = new GameProvidersNhRepository(SessionFactory);

        using (var trx = Session.BeginTransaction()) {
            gameProvidersRepo.SaveOrUpdate(gameProvider);
            trx.Commit();
        }

        Session.Clear(); // To clear cache so we can see select

        // Act
        GameProvider fetchedGameProvider = null;
        using (var trx = Session.BeginTransaction()) {
            fetchedGameProvider = gameProvidersRepo.GetById(gameProvider.Id);
            trx.Commit();
        }

        // Assert
        Assert.That(fetchedGameProvider, Is.Not.Null);
        Assert.That(fetchedGameProvider.ChangeStamp.CreatedOn.Kind, Is.EqualTo(DateTimeKind.Utc));
        Assert.That(fetchedGameProvider.ChangeStamp.UpdatedOn.Kind, Is.EqualTo(DateTimeKind.Utc));
    }

}
