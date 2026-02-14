using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using NHibernate.Util;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using Zed.DataAnnotations;

namespace Zeega.Infrastructure.GameProviders.GameDistribution {
    public class GameDistributionProvider : IGameDistributionProvider {

        #region Fields and Properties

        private const string BASE_API_URL = "https://games.gamedistribution.com/";

        private readonly Uri baseApiUrl;
        private readonly HttpClient httpClient;

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates Game Distribution provider instance for default base API URL
        /// </summary>
        public GameDistributionProvider() : this(BASE_API_URL) { }

        /// <summary>
        /// Creates Game Distribution provider instance for provided base API URL
        /// </summary>
        /// <param name="baseApiUrl">Base API URL on which Game Distribution service exists</param>
        /// <param name="httpClient">HttpClient</param>
        public GameDistributionProvider(string baseApiUrl, HttpClient httpClient = null) {
            this.baseApiUrl = new Uri(baseApiUrl);

            this.httpClient = httpClient ?? new HttpClient();
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<GameDistributionGame>> FetchGamesFeedCombinedAsync(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1) {
            var jsonGames = await FetchGamesFeedAsync(companyId, category, gameType, limit, offset, GameDistributionFeedFormatType.Json);
            var xmlGames = (await FetchGamesFeedAsync(companyId, category, gameType, limit, offset, GameDistributionFeedFormatType.Xml)).ToList();

            if (jsonGames == null) {
                jsonGames = new List<GameDistributionGame>();
            }

            foreach (var gameDistributionGame in jsonGames) {
                if (gameDistributionGame != null && !string.IsNullOrEmpty(gameDistributionGame.GameMd5)) {
                    var firstOrDefault = xmlGames.FirstOrDefault(x =>
                        x != null &&
                        !string.IsNullOrEmpty(x.GameMd5) &&
                        x.GameMd5.Equals(gameDistributionGame.GameMd5)
                    );

                    if (firstOrDefault != null) {
                        gameDistributionGame.LinkUrl = firstOrDefault.LinkUrl;
                    }

                }

            }

            return jsonGames;
        }

        public IEnumerable<GameDistributionGame> FetchGamesFeedCombined(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1) {
            return FetchGamesFeedCombinedAsync(companyId, category, gameType, limit, offset).Result;
        }

        /// <summary>
        /// https://games.gamedistribution.com/All/?category=All&Type=All&limit=10&offset=1&format=json
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GameDistributionGame>> FetchGamesFeedAsync(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1, GameDistributionFeedFormatType formatType = GameDistributionFeedFormatType.Xml) {
            var queryParams = new Dictionary<string, string?>
            {
                { "category", category },
                { "type", gameType.ToString() },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() },
                { "format", formatType.GetEnumDescription() }
            };
            var uriBuilder = new UriBuilder(baseApiUrl) {
                Path = $"{companyId}/",
                Query = QueryHelpers.AddQueryString(string.Empty, queryParams)
            };


            HttpResponseMessage httpResponse = null;
            try {
                httpResponse = await httpClient.GetAsync(uriBuilder.Uri).ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();
            } catch (HttpRequestException ex) {
                throw new HttpRequestExtException(httpResponse?.StatusCode ?? System.Net.HttpStatusCode.InternalServerError, ex.Message, ex);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return new List<GameDistributionGame>();
            }

            if (httpResponse == null) {
                return new List<GameDistributionGame>();
            }

            var response = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            IEnumerable<GameDistributionGame> gamesFeed;
            switch (formatType) {
                case GameDistributionFeedFormatType.Xml:
                    gamesFeed = CreateGameDistributionGamesFromXml(response);
                    break;
                case GameDistributionFeedFormatType.Json:
                    gamesFeed = CreateGameDistributionGamesFromJson(response);
                    break;
                default:
                    gamesFeed = null;
                    break;
            }

            return gamesFeed;

        }

        /// <summary>
        /// Gets a list of all shows in the TvMaze database andthe timestap when they
        /// were last updated.
        /// </summary>
        /// <returns>List of all updated shows</returns>
        public IEnumerable<GameDistributionGame> FetchGamesFeed(string companyId = "All", string category = "All", GameDiscributionGameType gameType = GameDiscributionGameType.All, int limit = 10, int offset = 1, GameDistributionFeedFormatType formatType = GameDistributionFeedFormatType.Xml) {
            return FetchGamesFeedAsync(companyId, category, gameType, limit, offset, formatType).Result;
        }

        /// <summary>
        /// Creates list of <see cref="GameDistributionGame"/> based on Json input data
        /// </summary>
        /// <param name="json">Json games data</param>
        /// <returns>List of game instance</returns>
        public static IList<GameDistributionGame> CreateGameDistributionGamesFromJson(string json) {
            if (string.IsNullOrEmpty(json)) throw new ArgumentNullException(nameof(json));

            IList<GameDistributionGame> games = new List<GameDistributionGame>();
            try {
                games = JsonConvert.DeserializeObject<IList<GameDistributionGame>>(json);
            } catch (Exception ex) {
                Trace.WriteLine(ex);
            }

            if (games == null) {
                return new List<GameDistributionGame>();
            }

            games.ForEach(x => {
                if (x != null && x.GameMd5 == null) {
                    x.GameMd5 = x.ExtractMd5FromExternalUrl();
                }
            });

            return games;
        }


        /// <summary>
        /// Creates list of <see cref="GameDistributionGame"/> based on Xml input data
        /// </summary>
        /// <param name="xml">Xml games data</param>
        /// <returns>List of game instance</returns>
        public static IList<GameDistributionGame> CreateGameDistributionGamesFromXml(string xml) {
            var games = new List<GameDistributionGame>();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            var xmlNodeList = xmlDocument.SelectNodes("/rss/channel/item");
            if (xmlNodeList != null) {
                foreach (XmlNode xmlNode in xmlNodeList) {
                    try {
                        var gameDistributionGame = new GameDistributionGame() {
                            Title = xmlNode["title"]?.InnerText,
                            CatTitle = xmlNode["category"]?.InnerText,
                            Description = xmlNode["description"]?.InnerText,
                            ExternalThumbUrl = xmlNode["image"]?["url"]?.InnerText,
                            ExternalUrl = xmlNode["location"]?["url"]?.InnerText,
                            LinkUrl = xmlNode["link"]?.InnerText,
                            AddedDate =
                                DateTime.ParseExact(xmlNode["pubDate"]?.InnerText, "M/d/yyyy h:mm:ss tt",
                                    CultureInfo.InvariantCulture)
                        };


                        gameDistributionGame.GameMd5 = gameDistributionGame.ExtractMd5FromExternalUrl();

                        games.Add(gameDistributionGame);

                    } catch (Exception e) {
                        Trace.WriteLine(e);
                    }

                }
            }


            return games;
        }

        #endregion
    }
}
