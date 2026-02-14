using Zed.Transaction;
using Zeega.Domain.GameModel;
using Zeega.Domain.GameProviders;
using Zeega.Domain.GameProviders.GameDistributionGame;
using Zeega.Infrastructure.GameProviders.GameDistribution;
using GameDiscributionGameType = Zeega.Domain.GameProviders.GameDistributionGame.GameDiscributionGameType;
using GameDistributionGame = Zeega.Infrastructure.GameProviders.GameDistribution.GameDistributionGame;

namespace Zeega.Infrastructure.GameProviders {
    public class GamesImporter {

        #region Fields and Properties

        private readonly IGameProvidersRepository gameProvidersRepository;
        private readonly IGamesImportsRepository gamesImportsRepository;
        private readonly IGameDistributionGamesRepository gameDistributionGamesRepository;
        private readonly IGameDistributionProvider gameDistributionProvider;

        #endregion

        #region Constructors and Init

        public GamesImporter(IGameProvidersRepository gameProvidersRepository, IGamesImportsRepository gamesImportsRepository, IGameDistributionGamesRepository gameDistributionGamesRepository, IGameDistributionProvider gameDistributionProvider = null) {
            this.gameProvidersRepository = gameProvidersRepository;
            this.gamesImportsRepository = gamesImportsRepository;
            this.gameDistributionGamesRepository = gameDistributionGamesRepository;
            this.gameDistributionProvider = gameDistributionProvider ?? new GameDistributionProvider();
        }

        #endregion

        #region Methods

        public void Import(IUnitOfWork unitOfWork) {
            ImportGameDistribution(unitOfWork);
        }

        public void ImportGameDistribution(IUnitOfWork unitOfWork) {


            var gameProvider = gameProvidersRepository.GetById((int)GameProvidersEnum.GameDistribution);
            var gamesImport = new GamesImport(gameProvider);

            var latestGameAddedDate = gameDistributionGamesRepository.GetLatestGameAddedDate();

            IEnumerable<GameDistributionGame> gameDistributionGames;
            var firstNewGameAddedDate = DateTime.MaxValue;
            int offset = 1;
            int entriesCounter = 0;
            do {
                gameDistributionGames = gameDistributionProvider.FetchGamesFeedCombined(offset: offset, limit: 40).ToList();

                var subsetOfGameDistributionGamesForProcessing = gameDistributionGames.Where(x =>
                        x.AddedDate != null
                    && x.AddedDate.Value > latestGameAddedDate     // to prevent processing data which was previousl processed
                    && x.AddedDate.Value < firstNewGameAddedDate   // to prevent processing the same data in further offsets if new data is added in source and offset is now shifted
                ).ToList();

                foreach (var gameDistributionGame in subsetOfGameDistributionGamesForProcessing) {

                    Domain.GameProviders.GameDistributionGame.GameDistributionGame game =
                        new Domain.GameProviders.GameDistributionGame.GameDistributionGame(gamesImport, gameDistributionGame.Id, gameDistributionGame.Title) {
                            Description = gameDistributionGame.Description,
                            CatTitle = gameDistributionGame.CatTitle,
                            Tags = gameDistributionGame.Tags,
                            ActivedDate = gameDistributionGame.ActivedDate,
                            AddedDate = gameDistributionGame.AddedDate ?? DateTime.UtcNow,
                            GameAddedDate = gameDistributionGame.GameAddedDate,
                            GameType = (GameDiscributionGameType)gameDistributionGame.GameType,
                            ExternalThumbUrl = gameDistributionGame.ExternalThumbUrl,
                            Thumbnail = gameDistributionGame.Thumbnail,
                            ExternalUrl = gameDistributionGame.ExternalUrl,
                            ExternalSrcUrl = gameDistributionGame.ExternalSWF,
                            LinkUrl = gameDistributionGame.LinkUrl,
                            Width = gameDistributionGame.Width,
                            Height = gameDistributionGame.Height,
                            GameMd5 = gameDistributionGame.GameMd5,
                        };

                    entriesCounter++;
                    gameDistributionGamesRepository.SaveOrUpdate(game);

                    if (firstNewGameAddedDate == DateTime.MaxValue) {
                        firstNewGameAddedDate = gameDistributionGame.AddedDate ?? DateTime.MaxValue;
                    }

                }

                offset++;
                if (subsetOfGameDistributionGamesForProcessing.Any()) {
                    unitOfWork.Commit();
                }

            } while (gameDistributionGames.Any()
               && latestGameAddedDate < gameDistributionGames.Min(x => x.AddedDate.Value)
            );

            if (entriesCounter > 0) {
                gamesImport.EntriesCount = entriesCounter;
                gamesImport.ImportEndDateTimeUtc = DateTime.UtcNow;
                gamesImportsRepository.SaveOrUpdate(gamesImport);
                unitOfWork.Commit();
            }

        }

        //public void ImportGameDistribution(IUnitOfWork unitOfWork) {
        //    var gameProvider = gameProvidersRepository.GetById((int) GameProvidersEnum.GameDistribution);
        //    var latestChangeDate = gamesRepository.GetLatestGameProviderChangeDate(gameProvider.Id);

        //    GameDistributionProvider gameDistributionProvider = new GameDistributionProvider();
        //    int offset = 1;
        //    IEnumerable<GameDistributionGame> gameDistributionGames;
        //    using (var scope = unitOfWork.Start()) {
        //        do {
        //            gameDistributionGames = gameDistributionProvider.FetchGamesFeedCombined(offset: offset, limit: 40);

        //            // fetch existing games for external id
        //            var persistedGames = gamesRepository.GetByExternalIds(gameDistributionGames.Select(x => x.Id.ToString()).ToList(), gameProvider.Id);

        //            foreach (var gameDistributionGame in gameDistributionGames) {
        //                Game game = null;
        //                if ((game = persistedGames.FirstOrDefault(x => x.ExternalId.Equals(gameDistributionGame.Id.ToString()))) != null) {
        //                    // existing game
        //                    game.ProviderUpdateDate = gameDistributionGame.AddedDate.Value;


        //                } else {
        //                    // game that does not exist in system

        //                    game = new Game(gameDistributionGame.Title, gameProvider) {
        //                        ExternalId = gameDistributionGame.Id.ToString(),
        //                        Description = gameDistributionGame.Description,
        //                        ProviderGameUrl = gameDistributionGame.LinkUrl,
        //                        ProviderPublishDate = gameDistributionGame.AddedDate.Value
        //                    };

        //                    if (gameDistributionGame.Width == null || gameDistributionGame.Height == null) {
        //                        if (gameDistributionGame.GameType == GameDiscributionGameType.Flash) {
        //                            var swfDimensions = getSwfDimensions(gameDistributionGame.ExternalUrl);
        //                            gameDistributionGame.Width = swfDimensions.Item1;
        //                            gameDistributionGame.Height = swfDimensions.Item2;
        //                        } else {
        //                            gameDistributionGame.Width = 0;
        //                            gameDistributionGame.Height = 0;
        //                        }

        //                    }

        //                    GameSrcType gameSrcType;
        //                    switch (gameDistributionGame.GameType) {
        //                        case GameDiscributionGameType.Html5:
        //                            gameSrcType = GameSrcType.Html;
        //                            break;
        //                        default:
        //                            gameSrcType = GameSrcType.Swf;
        //                            break;

        //                    }

        //                    game.GameSrc = GameSrc.CreateGameSrcWithUrl(gameDistributionGame.Width.Value, gameDistributionGame.Height.Value,
        //                        gameSrcType, gameDistributionGame.ExternalUrl);

        //                    var gameCategory = new GameCategory(gameDistributionGame.CatTitle);
        //                    gameCategory = gameCategoriesRepository.GetByExample(gameCategory) ?? gameCategory;
        //                    game.AddCategory(gameCategory);

        //                    gameDistributionGame.TagsList.Distinct()
        //                        .ForEach(x => {
        //                            var tag = Tag.CreateBaseTag(x);
        //                            tag = tagsRepository.GetByExample(tag) ?? tag;
        //                            game.AddTag(tag);
        //                        });

        //                    var imgDimensions = getImgDimensions(gameDistributionGame.ExternalThumbUrl);
        //                    game.CreateMediaResource(gameDistributionGame.ExternalThumbUrl, imgDimensions.Item1, imgDimensions.Item2, MediaResType.Thumbnail);

        //                    // TODO: fetch game files (thumbnails, images, swf, video)
        //                }

        //                gamesRepository.SaveOrUpdate(game);

        //            }
        //            offset++;
        //            scope.Commit();
        //        } while (gameDistributionGames != null && gameDistributionGames.Any()
        //           && latestChangeDate < gameDistributionGames.Min(x => x.AddedDate.Value)
        //        );
        //    }


        //}

        //private Tuple<int, int> getImgDimensions(string url) {
        //    byte[] imageData = new WebClient().DownloadData(url);
        //    Image img;
        //    using (var imgStream = new MemoryStream(imageData)) {
        //        img = Image.FromStream(imgStream);
        //    }

        //    return new Tuple<int, int>(img?.Width ?? 0, img?.Height ?? 0);
        //}

        //private Tuple<int, int> getSwfDimensions(string url) {
        //    byte[] swfData = new WebClient().DownloadData(url);
        //    var swfStream = new MemoryStream(swfData);
        //    SwfReader swfReader = null;
        //    SwfHeader swfHeader;
        //    try {
        //        swfReader = new SwfReader(swfStream);
        //        swfHeader = swfReader.ReadSwfHeader();
        //    } catch (Exception) {
        //        swfHeader = null;
        //    } finally {
        //        swfReader?.Close();
        //        swfStream.Close();
        //    }

        //    return new Tuple<int, int>(swfHeader?.Width ?? 0, swfHeader?.Height ?? 0);
        //}

        #endregion

    }
}
