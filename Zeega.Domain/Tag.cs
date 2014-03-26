using System;
using Zed.Core.Domain;
using Zed.Core.Utilities;

namespace Zeega.Domain {
    /// <summary>
    /// Entity class that represents Tag 
    /// </summary>
    public class Tag : Entity {

        #region Fields and Properties

        /// <summary>
        /// Tag name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets tag name
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value", "Tag name must contain some value.");

                name = value;
            }
        }


        /// <summary>
        /// Tag slug
        /// </summary>
        private string slug;

        /// <summary>
        /// Gets or Sets tag slug
        /// </summary>
        public string Slug { get { return slug; } }

        /// <summary>
        /// Gets or Sets two letter language code (ISO 639-1) of the tag
        /// </summary>
        public LanguageCode LanguageCode { get; set; }

        /// <summary>
        /// Base tag
        /// </summary>
        private readonly Tag baseTag;

        /// <summary>
        /// Gets base tag.
        /// </summary>
        public Tag BaseTag { get { return baseTag; }}

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates instance of Tag class with provided tag name.
        /// Slug is automatticaly generated based on tag name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="languageCode">two letter language code (ISO 639-1) of the tag</param>
        internal Tag(string name, LanguageCode languageCode) : this(name, name, languageCode) { }

        /// <summary>
        /// Creates instance of Tag class with provided tag name and slug
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="slug">Tag slug</param>
        /// <param name="languageCode">two letter language code (ISO 639-1) of the tag</param>
        internal Tag(string name, string slug, LanguageCode languageCode) {
            Name = name;
            SetSlug(slug);

            if (languageCode == null) throw new ArgumentNullException("languageCode", "LanguageCode must have some value");
            LanguageCode = languageCode;

            baseTag = null;
        }

        /// <summary>
        /// Creates instance of Tag class with provided tag name, slug and base tag
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="slug">Tag slug</param>
        /// <param name="languageCode">two letter language code (ISO 639-1) of the tag</param>
        /// <param name="baseTag">Basetag</param>
        internal Tag(string name, string slug, LanguageCode languageCode, Tag baseTag) : this(name, slug, languageCode) {
            this.baseTag = baseTag;
        } 

        /// <summary>
        /// Creates instance of Tag class with provided tag name and base tag
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="languageCode">two letter language code (ISO 639-1) of the tag</param>
        /// <param name="baseTag">Basetag</param>
        internal Tag(string name, LanguageCode languageCode, Tag baseTag) : this(name, name, languageCode, baseTag) { }

        #endregion

        #region Methods

        /// <summary>
        /// Sets provided argument to slug. If necessary provided argument is transformed
        /// to slug form.
        /// </summary>
        /// <param name="slugValue">Slug value</param>
        public void SetSlug(string slugValue) {
            if (String.IsNullOrWhiteSpace(slugValue)) throw new ArgumentNullException("slugValue", "Tag slugValue must contain some value.");

            slug = slugValue.ToSlug();
        }

        /// <summary>
        /// Creates tag based on primary application tenant.
        /// Tag will have language code as the primary application tenat has.
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="slug">Tag slug</param>
        /// <param name="appTenant">Primary application tenant</param>
        /// <returns>Created tag</returns>
        public static Tag CreateTag(string name, string slug, AppTenant appTenant) {
            if(!appTenant.IsPrimary) throw new ArgumentException("AppTenant must be primary");
            return new Tag(name, slug, appTenant.LanguageCode);
        }

        /// <summary>
        /// Creates tag based on primary application tenant.
        /// Tag will have language code as the primary application tenat has.
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="appTenant">Primary application tenant</param>
        /// <returns>Created tag</returns>
        public static Tag CreateTag(string name, AppTenant appTenant) { return CreateTag(name, name, appTenant); }


        /// <summary>
        /// Creates tag with reference to base tag.
        /// If language code of the base tag is equal to provided language code then
        /// base tag is returned.
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="slug">Tag slug</param>
        /// <param name="languageCode">Language code of tag</param>
        /// <param name="baseTag">Base tag</param>
        /// <returns>Created tag</returns>
        public static Tag CreateTag(string name, string slug, LanguageCode languageCode, Tag baseTag) {
            if(baseTag.BaseTag != null) throw new ArgumentException("Provided Tag is not base tag, it must have null value setto BaseTag property.", "baseTag");
            return baseTag.LanguageCode.Equals(languageCode) ? baseTag : new Tag(name, slug, languageCode, baseTag);
        }

        /// <summary>
        /// Creates tag with reference to base tag.
        /// If language code of the base tag is equal to provided language code then
        /// base tag is returned.
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <param name="languageCode">Language code of tag</param>
        /// <param name="baseTag">Base tag</param>
        /// <returns>Created tag</returns>
        public static Tag CreateTag(string name, LanguageCode languageCode, Tag baseTag) { return CreateTag(name, name, languageCode, baseTag); }

        #endregion

    }
}
