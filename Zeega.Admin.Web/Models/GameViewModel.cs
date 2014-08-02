using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zeega.Admin.Web.Models {
    /// <summary>
    /// Game view model
    /// </summary>
    public class GameViewModel {

        #region Fields and Properties

        /// <summary>
        /// Gats or Sets game's id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets game's name
        /// </summary>
        [Required(ErrorMessage = "Please enter a game name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets game external/original Id
        /// </summary>
        [Display(Name = "External Id")]
        [Required(ErrorMessage = "Please enter game external/original Id.")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Game categories
        /// </summary>
        [Display(Name = "Categories")]
        [Required]
        public string Categories { get; set; }

        /// <summary>
        /// Gets or Sets the full text description of the game
        /// </summary>
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets short text description of game.
        /// </summary>
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or Sets game instructions
        /// </summary>
        [Display(Name = "Instructions")]
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }

        /// <summary>
        /// Game controls
        /// </summary>
        [Display(Name = "Controls")]
        public string Controls { get; set; }

        /// <summary>
        /// Gets list of game tags/keywords
        /// </summary>
        [Display(Name = "Tags")]
        public string Tags { get; set; }


        /// <summary>
        /// Gets or Sets media resources of the game
        /// like thumbnails, screenshots and video
        /// </summary>
        [Display(Name = "Media resources")]
        public IList<MediaResViewModel> MediaResources { get; set; }

        /// <summary>
        /// Gets or Sets game source
        /// </summary>
        public GameSrcViewModel GameSrc { get; set; }

        /// <summary>
        /// Game's provider
        /// </summary>
        [Display(Name = "Provider")]
        [Required]
        public string Provider { get; set; }

        /// <summary>
        /// Game's provider URL
        /// </summary>
        [Display(Name = "Game provider URL")]
        [DataType(DataType.Url)]
        [Required]
        public string ProviderUrl { get; set; }

        /// <summary>
        /// A URL where the game is located (the developer's or provider's site)
        /// </summary>
        [Display(Name = "Provider's game URL")]
        [DataType(DataType.Url)]
        [Required]
        public string ProviderGameUrl { get; set; }

        /// <summary>
        /// Game author
        /// </summary>
        [Display(Name = "Author")]
        public string Author { get; set; }

        /// <summary>
        /// Game author URL
        /// </summary>
        [Display(Name = "Author URL")]
        [DataType(DataType.Url)]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// URL of a zip package containing the thumb, game SWF, and meta data
        /// </summary>
        [Display(Name = "ZIP package URL")]
        [DataType(DataType.Url)]
        public string ZipUrl { get; set; }

        /// <summary>
        /// Gets or Sets the indicator that indicates whether the zip archive was downloaded
        /// </summary>
        [Display(Name = "Is ZIP package downloaded?")]
        public bool IsZipDownloaded { get; set; }

        /// <summary>
        /// Game change stamp
        /// </summary>
        //public ChangeStamp ChangeStamp { get; set; }

        #endregion
    }
}