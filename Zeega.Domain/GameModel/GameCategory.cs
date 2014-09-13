using System;
using Zed.Domain;
using Zed.Utilities;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Represents game category entity
    /// </summary>
    public class GameCategory : Entity {

        #region Fields and Properties

        /// <summary>
        /// Game category name
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Gets category name
        /// </summary>
        public virtual string Name { get { return name; } }

        /// <summary>
        /// Game category slug
        /// </summary>
        private readonly string slug;

        /// <summary>
        /// Gets game category slug
        /// </summary>
        public virtual string Slug { get { return slug; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor
        /// </summary>
        protected GameCategory() { }

        /// <summary>
        /// Creates game category based on provided params
        /// </summary>
        /// <param name="name">Game category name</param>
        public GameCategory(string name) : this(name, name.ToSlug()) { }

        /// <summary>
        /// Creates game category based on provided params.
        /// </summary>
        /// <param name="name">Game category name</param>
        /// <param name="slug">Game category slug</param>
        public GameCategory(string name, string slug) {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "Game category name can't be undfined.");
            this.name = name;

            if (string.IsNullOrEmpty(slug)) throw new ArgumentNullException("name", "Game category slug can't be undfined.");
            this.slug = slug;
        }

        #endregion

        #region Methods

        #endregion

    }
}
