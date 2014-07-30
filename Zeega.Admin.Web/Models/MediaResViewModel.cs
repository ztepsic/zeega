using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Zeega.Domain.GameModel;

namespace Zeega.Admin.Web.Models {
    /// <summary>
    /// Media resource view model
    /// </summary>
    public class MediaResViewModel {

        /// <summary>
        /// Gets or sets media resource type
        /// </summary>
        [Required]
        public MediaResType Type { get; set; }

        /// <summary>
        /// Gets media resource types
        /// </summary>
        public SelectList Types { get { return new SelectList(Enum.GetNames(typeof(MediaResType)));} }

        /// <summary>
        /// Gets or sets thubmnail of media resource URI
        /// </summary>
        [Display(Name = "Thumbnail URI")]
        [DataType(DataType.Url)]
        [Required]
        public string ThumbSrcUri { get; set; }


        /// <summary>
        /// Gets or sets thumbnail of media resource width in pixels
        /// </summary>
        [Display(Name = "Thumbnail width")]
        [Required]
        public int ThumbSrcWidth { get; set; }

        /// <summary>
        /// Gets or sets thumbnail media resource height in pixels
        /// </summary>
        [Display(Name = "Thumbnail height")]
        [Required]
        public int ThumbSrcHeight { get; set; }

        /// <summary>
        /// Gets or sets media resource URI
        /// </summary>
        [Display(Name = "Source URI")]
        [DataType(DataType.Url)]
        public string SrcUri { get; set; }

        /// <summary>
        /// Gets or sets media resource width in pixels
        /// </summary>
        [Display(Name = "Source width")]
        public int SrcWidth { get; set; }

        /// <summary>
        /// Gets or sets media resource height in pixels
        /// </summary>
        [Display(Name = "Source height")]
        public int SrcHeight { get; set; }

        /// <summary>
        /// MediaRes order sequence
        /// </summary>
        [Display(Name = "Sequence")]
        [Required]
        public short Sequence { get; set; }

        /// <summary>
        /// Gets or Sets indicator which indicate is media resource active
        /// </summary>
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
    }
}