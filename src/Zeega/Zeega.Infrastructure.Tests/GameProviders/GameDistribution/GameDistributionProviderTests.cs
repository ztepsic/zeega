using RichardSzalay.MockHttp;
using System.Globalization;
using Zeega.Infrastructure.GameProviders.GameDistribution;

namespace Zeega.Infrastructure.Tests.GameProviders.GameDistribution {
    [TestFixture]
    public class GameDistributionProviderTests {

        public const string DATA_PATH = @"GameProviders/GameDistribution/data_examples/";
        private const string BASE_API_URL = "http://localhost";

        public string BasePath { get; set; }

        [SetUp]
        public void SetUp() {
            BasePath = AppDomain.CurrentDomain.BaseDirectory;
        }

        [Test]
        public void CreateGameDistributionGamesFromJson_ValidGamesFeedJsonData_GamesList() {
            // Arrange
            var json = File.ReadAllText(Path.Combine(BasePath, DATA_PATH, "gamedistribution_games_feed_01.json"));

            // Act
            var gamesFeed = GameDistributionProvider.CreateGameDistributionGamesFromJson(json);

            // Assert
            Assert.That(gamesFeed, Is.Not.Null);
            Assert.That(gamesFeed, Has.Count.EqualTo(10));

            var game01 = gamesFeed[0];
            Assert.That(game01.ActivedDate, Is.Null);
            Assert.That(game01.AddedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512999649873).DateTime));
            Assert.That(game01.CatTitle, Is.EqualTo("Mahjong"));
            Assert.That(game01.Description, Is.EqualTo("Krismas Mahjong is a Christmas Version of Kris Mahjong. A very popular Mahjong game. \r\nConnect the mahjong pieces in KrisMas Mahjong. Clear the board by removing all pairs of identical tiles"));
            Assert.That(game01.ExternalThumbUrl, Is.EqualTo("http://img.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320.jpg"));
            Assert.That(game01.ExternalUrl, Is.EqualTo("http://html5.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320/"));
            Assert.That(game01.GameAddedDate, Is.Null);
            Assert.That((int)game01.GameType, Is.EqualTo(5));
            Assert.That(game01.Height, Is.EqualTo(500));
            Assert.That(game01.Id, Is.EqualTo(14412));
            Assert.That(game01.RegId, Is.EqualTo("15DD06FF-E28C-40A6-AA97-0E9D12B41A00"));
            Assert.That(game01.RowNumber, Is.EqualTo(1));
            Assert.That(game01.Tags, Is.EqualTo("mahjong,christmas,KRISTOFF,CONNECT,CONNECT2,CONNECT-2"));
            Assert.That(game01.Thumbnail, Is.EqualTo("63fe5e9aa5c84c46988cac2d9f617320.jpg"));
            Assert.That(game01.Title, Is.EqualTo("KrisMas Mahjong"));
            Assert.That(game01.Width, Is.EqualTo(800));
            Assert.That(game01.GameMd5, Is.EqualTo("63fe5e9aa5c84c46988cac2d9f617320"));

            var game02 = gamesFeed[1];
            Assert.That(game02.ActivedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512471213250).DateTime));
            Assert.That(game02.AddedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512989858030).DateTime));
            Assert.That(game02.GameAddedDate, Is.EqualTo("05.12.2017 10:53:33"));

        }

        [Test]
        public void CreateGameDistributionGamesFromXml_ValidGamesFeedXmlData_GamesList() {
            // Arrange
            var xml = File.ReadAllText(Path.Combine(BasePath, DATA_PATH, "gamedistribution_games_feed_01.xml"));

            // Act
            var gamesFeed = GameDistributionProvider.CreateGameDistributionGamesFromXml(xml);

            // Assert
            Assert.That(gamesFeed, Is.Not.Null);
            Assert.That(gamesFeed.Count, Is.EqualTo(10));

            var game01 = gamesFeed[0];
            Assert.That(game01.Title, Is.EqualTo("KrisMas Mahjong"));
            Assert.That(game01.CatTitle, Is.EqualTo("Mahjong"));
            Assert.That(game01.Description, Is.EqualTo(@"Krismas Mahjong is a Christmas Version of Kris Mahjong. A very popular Mahjong game. 
Connect the mahjong pieces in KrisMas Mahjong. Clear the board by removing all pairs of identical tiles"));
            Assert.That(game01.ExternalThumbUrl, Is.EqualTo("http://img.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320.jpg"));
            Assert.That(game01.ExternalUrl, Is.EqualTo("http://html5.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320/"));
            Assert.That(game01.LinkUrl, Is.EqualTo("http://www.gamedistribution.com/games/Mahjong/KrisMas-Mahjong.html"));
            Assert.That(game01.AddedDate, Is.EqualTo(DateTime.ParseExact("12/11/2017 1:40:49 PM", "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)));
            Assert.That(game01.GameMd5, Is.EqualTo("63fe5e9aa5c84c46988cac2d9f617320"));


            var game02 = gamesFeed[1];
            Assert.That(game02.Title, Is.EqualTo("Gummy Blocks"));


        }


        [Test]
        public void FetchGamesFeed_CombinedJsonAndXmlGamesList() {
            // Arrange
            var json = File.ReadAllText(Path.Combine(BasePath, DATA_PATH, "gamedistribution_games_feed_01.json"));
            var xml = File.ReadAllText(Path.Combine(BasePath, DATA_PATH, "gamedistribution_games_feed_01.xml"));
            var mockHttp = new MockHttpMessageHandler();

            // http://localhost/All/?category=All&type=All&limit=10&offset=1&format=Json
            mockHttp.Expect($"{BASE_API_URL}/All/")
                .WithQueryString("category", "All")
                .WithQueryString("type", "All")
                .WithQueryString("limit", "10")
                .WithQueryString("offset", "1")
                .WithQueryString("format", "json")
                .Respond("application/json", json);

            mockHttp.Expect($"{BASE_API_URL}/All/")
                .WithQueryString("category", "All")
                .WithQueryString("type", "All")
                .WithQueryString("limit", "10")
                .WithQueryString("offset", "1")
                .WithQueryString("format", "xml")
                .Respond("application/xml", xml);

            var gameDistributionProvider = new GameDistributionProvider(BASE_API_URL, mockHttp.ToHttpClient());

            // Act
            var gamesFeed = gameDistributionProvider.FetchGamesFeedCombined().ToList();

            // Assert
            Assert.That(gamesFeed, Is.Not.Null);
            Assert.That(gamesFeed.Count, Is.EqualTo(10));

            var game01 = gamesFeed[0];
            Assert.That(game01.ActivedDate, Is.Null);
            Assert.That(game01.AddedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512999649873).DateTime));
            Assert.That(game01.CatTitle, Is.EqualTo("Mahjong"));
            Assert.That(game01.Description, Is.EqualTo("Krismas Mahjong is a Christmas Version of Kris Mahjong. A very popular Mahjong game. \r\nConnect the mahjong pieces in KrisMas Mahjong. Clear the board by removing all pairs of identical tiles"));
            Assert.That(game01.ExternalThumbUrl, Is.EqualTo("http://img.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320.jpg"));
            Assert.That(game01.ExternalUrl, Is.EqualTo("http://html5.GameDistribution.com/63fe5e9aa5c84c46988cac2d9f617320/"));
            Assert.That(game01.LinkUrl, Is.EqualTo("http://www.gamedistribution.com/games/Mahjong/KrisMas-Mahjong.html"));
            Assert.That(game01.GameAddedDate, Is.Null);
            Assert.That((int)game01.GameType, Is.EqualTo(5));
            Assert.That(game01.Height, Is.EqualTo(500));
            Assert.That(game01.Id, Is.EqualTo(14412));
            Assert.That(game01.RegId, Is.EqualTo("15DD06FF-E28C-40A6-AA97-0E9D12B41A00"));
            Assert.That(game01.RowNumber, Is.EqualTo(1));
            Assert.That(game01.Tags, Is.EqualTo("mahjong,christmas,KRISTOFF,CONNECT,CONNECT2,CONNECT-2"));
            Assert.That(game01.Thumbnail, Is.EqualTo("63fe5e9aa5c84c46988cac2d9f617320.jpg"));
            Assert.That(game01.Title, Is.EqualTo("KrisMas Mahjong"));
            Assert.That(game01.Width, Is.EqualTo(800));
            Assert.That(game01.GameMd5, Is.EqualTo("63fe5e9aa5c84c46988cac2d9f617320"));

            var game02 = gamesFeed[1];
            Assert.That(game02.ActivedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512471213250).DateTime));
            Assert.That(game02.AddedDate, Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1512989858030).DateTime));
            Assert.That(game02.GameAddedDate, Is.EqualTo("05.12.2017 10:53:33"));
            Assert.That(game02.LinkUrl, Is.EqualTo("http://www.gamedistribution.com/games/Match-3/Gummy-Blocks.html"));
            Assert.That(game02.GameMd5, Is.EqualTo("a5b8f662ca434d9391935c97f245e719"));

        }

        //[Test]
        //public async Task FetchGamesFeedAsync_MockWebApi_JsonData_GamesList() {
        //    //// Arrange
        //    //var json = File.ReadAllText(Path.Combine(BasePath, DomainObjectFactoryTests.JSON_DATA_PATH, "person.json"));
        //    //var mockHttp = new MockHttpMessageHandler();
        //    //mockHttp.Expect($"{BASE_API_URL}/people/{personId}")
        //    //    .Respond("application/json", json);

        //    //var tvMazeClient = new TvMazeClient(BASE_API_URL, mockHttp.ToHttpClient());

        //    //// Act
        //    //var person = await tvMazeClient.GetPersonInfoAsync(personId.ToString());

        //    //// Assert
        //    //Assert.IsNotNull(person);
        //    //Assert.AreEqual(personId, person.Id);
        //    //mockHttp.VerifyNoOutstandingExpectation();
        //}
    }
}
