using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web.Models.Game {
    /// <summary>
    /// Game device type support view model
    /// </summary>

    public class DeviceTypeSupportViewModel {

        /// <summary>
        /// Gets or set an indicator which indicates if a desktop device is enbled
        /// </summary>
        [Display(Name = "Desktop")]
        public bool IsDesktopEnabled { get; set; }

        /// <summary>
        /// Gets or sets an indicator which indicates if a mobile device is enabled
        /// </summary>
        [Display(Name = "Mobile")]
        public bool IsMobileEnabled { get; set; }

    }

    /// <summary>
    /// Game source view model
    /// </summary>
    public class GameSrcViewModel {

        /// <summary>
        /// Gets or sets game width in pixels
        /// </summary>
        [Required]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets game height in pixels
        /// </summary>
        [Required]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets a game source URI
        /// </summary>
        [Display(Name = "Game source URI")]
        [DataType(DataType.Url)]
        [Required]
        public string SrcUri { get; set; }

        /// <summary>
        /// Gets or Sets the indicator if game source is online/live (true) or offline (false)
        /// </summary>
        [Display(Name = "Is game source online?")]
        public bool IsSrcOnline { get; set; }

        /// <summary>
        /// Gets or Sets device type support
        /// </summary>
        [Display(Name = "Device type support")]
        [Required]
        public DeviceTypeSupportViewModel DeviceTypeSupport { get; set; }


        /// <summary>
        /// Gets or sets game source type
        /// </summary>
        [Display(Name = "Game source type")]
        [Range(1, 2, ErrorMessage = "You must choose a valid game source type.")]
        [Required]
        public GameSrcType SrcType { get; set; }

        /// <summary>
        /// Gets game source types
        /// </summary>
        public SelectList SrcTypes { get { return new SelectList(Enum.GetNames(typeof(GameSrcType)));} }
    }
}