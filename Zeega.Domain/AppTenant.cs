using System;
using Zed.Core.Domain;
using Zed.Core.Utilities;

namespace Zeega.Domain {
    /// <summary>
    /// Represents application's tenant in multitenant environement
    /// </summary>
    public class AppTenant : Entity {

        #region Fields and Properties

        /// <summary>
        /// Application tenant code
        /// </summary>
        private readonly string code;

        /// <summary>
        /// Gets application tenant code
        /// </summary>
        public virtual string Code { get { return code; } }

        /// <summary>
        /// Application tenant name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or Sets application tenant name
        /// </summary>
        public virtual string Name {
            get { return name; }
            set {
                if (value == null) throw new ArgumentNullException();

                name = value;
            }
        }

        /// <summary>
        /// Two letter language code (ISO 639-1) of the application tenant
        /// E.g. en, de, hr
        /// </summary>
        private readonly LanguageCode languageCode;

        /// <summary>
        /// Gets two letter language code (ISO 639-1) of the application tenant
        /// </summary>
        public virtual LanguageCode LanguageCode { get { return languageCode; } }

        /// <summary>
        /// Value that indicates the primary application tenant
        /// </summary>
        private readonly bool isPrimary;

        /// <summary>
        /// Gets value that indicates the primary application tenant
        /// </summary>
        public virtual bool IsPrimary { get { return isPrimary; } }

        /// <summary>
        /// Gets or Sets application tenant description
        /// </summary>
        public virtual string Description { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor that creates a new instance of AppTenant class.
        /// </summary>
        protected AppTenant() { }

        /// <summary>
        /// Creates a new instance of AppTenant class for the specified tenant name
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <param name="languageCode">Language code of the application tenatn</param>
        public AppTenant(string name, LanguageCode languageCode) : this(name, name.ToSlug(), languageCode, false) { }

        /// <summary>
        /// Creates a new instance of AppTenant class for the specified tenant name
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <param name="languageCode">Language code of the application tenatn</param>
        /// <param name="isPrimary">Value that indicates the primary application tenant</param>
        public AppTenant(string name, LanguageCode languageCode, bool isPrimary) : this(name, name.ToSlug(), languageCode, isPrimary) { }

        /// <summary>
        /// Creates a new instance of AppTenant class for the specified tenant name
        /// </summary>
        /// <param name="name">Application tenant name</param>
        /// <param name="code">Application tenant code</param>
        /// <param name="languageCode">Language code of the application tenant</param>
        /// <param name="isPrimary">Value that indicates the primary application tenant</param>
        public AppTenant(string name, string code, LanguageCode languageCode, bool isPrimary) {
            Name = name;

            if(String.IsNullOrEmpty(code)) throw new ArgumentNullException("code", "Code must have some value.");
            this.code = code;

            if (languageCode == null) throw new ArgumentNullException("languageCode", "LanguageCode must have some value");
            this.languageCode = languageCode;

            this.isPrimary = isPrimary;

        }

        #endregion

        #region Methods

        #endregion

    }
}
