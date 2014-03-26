using System;
using Zed.Core.Utilities;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents game category entity
    /// </summary>
    public class GameCategory {

        #region Fields and Properties

        /// <summary>
        /// Application tenant that owns this game category instance
        /// </summary>
        private readonly AppTenant appTenant;

        /// <summary>
        /// Gets application tenant that owns this game category instance
        /// </summary>
        public AppTenant AppTenant { get { return appTenant; } }

        /// <summary>
        /// Game category name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets game category name
        /// </summary>
        public virtual string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Game category name must contain some value.");

                name = value;
            }
        }

        /// <summary>
        /// Game category slug value
        /// </summary>
        private string slug;

        /// <summary>
        /// Gets game category slugValue
        /// </summary>
        public virtual string Slug {
            get { return slug; }
        }

        /// <summary>
        /// Game category order sequence
        /// </summary>
        public short Sequence { get; set; }

        /// <summary>
        /// Full text description of the game category
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Short text description of the game category
        /// </summary>
        public virtual string ShortDescription { get; set; }

        /// <summary>
        /// Keywords of the game category separated by commas
        /// TODO: create array of keywords with additional addKeyword method
        /// </summary>
        public virtual string Keywords { get; set; }

        #endregion

        #region Constructors and init

        /// <summary>
        /// Creates the instance of the GameCategory class with provided game category name
        /// and automatticaly creates game category slugValue
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game</param>
        /// <param name="name">Game category name</param>
        public GameCategory(AppTenant appTenant, string name) : this(appTenant, name, name) { }

        /// <summary>
        /// Creates the instance of the GameCategory class with provided game category name
        /// and slugValue.
        /// </summary>
        /// <param name="appTenant">Application tenant that owns this game</param>
        /// <param name="name">Game category name</param>
        /// <param name="slug">Game category slugValue</param>
        public GameCategory(AppTenant appTenant, string name, string slug) {
            this.appTenant = appTenant;
            Name = name;
            SetSlug(slug);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets provided argument to slug. If necessary provided argument is transformed
        /// to slug form.
        /// </summary>
        /// <param name="slugValue">Slug value</param>
        public void SetSlug(string slugValue) {
            if (String.IsNullOrWhiteSpace(slugValue)) throw new ArgumentNullException("slugValue", "Game category slugValue must contain some value.");

            slug = slugValue.ToSlug();
        }

        #endregion

    }
}
