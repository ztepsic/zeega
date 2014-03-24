using Zed.Core.Utilities;

namespace Zeega.Domain {
    /// <summary>
    /// Represents Tag
    /// </summary>
    public class Tag {

        #region Fields and Properties

        /// <summary>
        /// Tag name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tag slug
        /// </summary>
        public string Slug { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of Tag class with provided tag name.
        /// Slug is automatticaly generated based on tag name.
        /// </summary>
        /// <param name="name"></param>
        public Tag(string name) : this(name, name) { }

        /// <summary>
        /// Creates instance of Tag class with provided tag name and slug
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="slug">Tag slug</param>
        public Tag(string name, string slug) {
            Name = name;
            Slug = slug.ToSlug();
        }

        #endregion

        #region Methods
        #endregion

    }
}
