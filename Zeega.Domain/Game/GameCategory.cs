using System;
using Zed.Core.Utilities;

namespace Zeega.Domain.Game {
    /// <summary>
    /// Represents game category entity
    /// </summary>
    public class GameCategory {

        #region Fields and Properties

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
                if (value == null) throw new ArgumentNullException();

                name = value;
            }
        }

        /// <summary>
        /// Game category slug
        /// </summary>
        private string slug;

        /// <summary>
        /// Gets or Sets game category slug
        /// </summary>
        public virtual string Slug {
            get { return slug; }
            set {
                if(value == null) throw new ArgumentNullException();

                slug = value.ToSlug();
            }
        }

        /// <summary>
        /// Full text description of the game category
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Short text description of the game category
        /// TODO: Set max number of characters or words
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
        /// and automatticaly creates game category slug
        /// </summary>
        /// <param name="name">Game category name</param>
        public GameCategory(string name) : this(name, name) { }

        /// <summary>
        /// Creates the instance of the GameCategory class with provided game category name
        /// and slug.
        /// </summary>
        /// <param name="name">Game category name</param>
        /// <param name="slug">Game category slug</param>
        public GameCategory(string name, string slug) {
            if (name == null) throw new ArgumentNullException();
            if (slug == null) throw new ArgumentNullException();

            this.name = name;
            this.slug = slug.ToSlug();
        }

        #endregion

        #region Methods

        #endregion

    }
}
