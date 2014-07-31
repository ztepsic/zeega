using System.ComponentModel.DataAnnotations;

namespace Zeega.Admin.Web.Models.Game {

    public class GameProviderModel {

        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets game provider's name
        /// </summary>
        [Required(ErrorMessage = "Please enter a game provider's name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets game provider's official URL
        /// </summary>
        [Display(Name = "Official URL")]
        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Please enter a game provider's official URL.")]
        public string OfficialUrl { get; set; }

        /// <summary>
        /// Gets or Sets game provider's publisher URL
        /// </summary>
        [Display(Name = "Publisher URL")]
        [DataType(DataType.Url)]
        public string PublisherUrl { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has publisher API
        /// </summary>
        [Display(Name = "Has publisher Api?")]
        public bool HasPublisherApi { get; set; }

        /// <summary>
        /// Gets or Sets game provider's catalog URL
        /// </summary>
        [Display(Name = "Games Catalog URL")]
        [DataType(DataType.Url)]
        public string GamesCatalogUrl { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has xml game feed
        /// </summary>
        [Display(Name = "Has a XML feed?")]
        public virtual bool HasXmlFeed { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider has json game feed
        /// </summary>
        [Display(Name = "Has a JSON feed?")]
        public virtual bool HasJsonFeed { get; set; }

        /// <summary>
        /// Gets or Sets an indicator which indicates if provider is active
        /// </summary>
        [Display(Name = "Is the game publisher active?")]
        public virtual bool IsActive { get; set; }

    }
}