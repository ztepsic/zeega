using System.Web;

namespace Zeega.Infrastructure.GameProviders.GameDistribution {
    public class GameDistributionGame {

        #region Fields and Properties

        /// <summary>
        /// Game Id
        /// </summary>
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Category title
        /// </summary>
        public string CatTitle { get; set; }

        public string Tags { get; set; }

        public DateTime? ActivedDate { get; set; }

        public DateTime? AddedDate { get; set; }

        /// <summary>
        /// "GameAddedDate": "10.12.2017 14:39:36",
        /// </summary>
        public string GameAddedDate { get; set; }

        /// <summary>
        /// External thumbnail url
        /// </summary>
        public string ExternalThumbUrl { get; set; }

        public string Thumbnail { get; set; }

        /// <summary>
        /// External game url
        /// </summary>
        public string ExternalUrl { get; set; }

        public string ExternalSWF { get; set; }

        /// <summary>
        /// Provider's Web page of the game
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// Game type like Html5 or Flash
        /// </summary>
        public GameDiscributionGameType GameType { get; set; }

        /// <summary>
        /// Game Width
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Game height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Game company Id
        /// "RegId": "15DD06FF-E28C-40A6-AA97-0E9D12B41A00",
        /// </summary>
        public string RegId { get; set; }

        /// <summary>
        /// Row number
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// Game MD5 hash
        /// </summary>
        public string GameMd5 { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method extracts Md5 hash from external url property
        /// </summary>
        /// <returns>Extracted Md5 hash</returns>
        public string ExtractMd5FromExternalUrl() {
            if (string.IsNullOrEmpty(ExternalUrl)) {
                return null;
            }

            var externalUrl = new Uri(ExternalUrl);
            var gameMd5 = HttpUtility.ParseQueryString(externalUrl.Query).Get("game") ??
                          externalUrl.AbsolutePath.Trim('/');

            return gameMd5;
        }

        #endregion

    }
}
