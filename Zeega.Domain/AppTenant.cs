using System;
using System.Text.RegularExpressions;
using Zed.Core.Domain;

namespace Zeega.Domain {
    /// <summary>
    /// Represents application's tenant in multitenant environement
    /// </summary>
    public class AppTenant : Entity {

        #region Constants

        /// <summary>
        /// Two letter language code (ISO 639-1) pattern
        /// </summary>
        private const string TWO_LETTER_LANGUAGE_CODE_PATTERN = "^[a-zA-Z]{2}$";

        #endregion

        #region Fields and Properties

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
        private string languageCode;

        /// <summary>
        /// Gets or Sets two letter language code (ISO 639-1) of the application tenant
        /// </summary>
        public string LanguageCode {
            get { return languageCode; }
            set {
                if(String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Language code must contain some value.");
                if (!new Regex(TWO_LETTER_LANGUAGE_CODE_PATTERN).IsMatch(value)) {
                    throw new ArgumentException("Language code must be two letters code (ISO 639-1).");
                }

                languageCode = value.ToLower();
            }
        }

        /// <summary>
        /// Gets or Sets value that indicates the primary application tenant
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or Sets application tenant description
        /// </summary>
        public virtual string Description { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates a new instance of AppTenant class for the specified tenant name
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <param name="languageCode">Language code of the application tenatn</param>
        public AppTenant(string name, string languageCode) {
            Name = name;
            LanguageCode = languageCode;
        }

        #endregion

        #region Methods

        #endregion

    }
}
