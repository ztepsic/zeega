using System;
using System.Text.RegularExpressions;
using Zed.Core.Domain;

namespace Zeega.Domain {
    /// <summary>
    /// Two letter language code (ISO 639-1) of the application tenant
    /// </summary>
    public class LanguageCode : ValueObject {

        #region Constants

        /// <summary>
        /// Two letter language code (ISO 639-1) pattern
        /// </summary>
        private const string TWO_LETTER_LANGUAGE_CODE_PATTERN = "^[a-zA-Z]{2}$";

        /// <summary>
        /// English two letter (ISO 639-1) language code
        /// </summary>
        public const string ENGLISH_TWO_LETTER_CODE = "en";

        /// <summary>
        /// Croatian two letter (ISO 639-1) language code
        /// </summary>
        public const string CROATIAN_TWO_LETTER_CODE = "hr";

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Two letter language code (ISO 639-1) of the application tenant
        /// E.g. en, de, hr
        /// </summary>
        private readonly string value;

        /// <summary>
        /// Gets two letter language code (ISO 639-1) of the application tenant
        /// </summary>
        public string Value { get { return value; } }

        #endregion

        #region Consructors and Init

        /// <summary>
        /// C
        /// </summary>
        /// <param name="languageCode"></param>
        public LanguageCode(string languageCode) {
            if (String.IsNullOrWhiteSpace(languageCode)) throw new ArgumentNullException("languageCode", "Language code must contain some value.");
            if (!new Regex(TWO_LETTER_LANGUAGE_CODE_PATTERN).IsMatch(languageCode)) {
                throw new ArgumentException("Language code must be two letters code (ISO 639-1).");
            }

            value = languageCode.ToLower();
        }

        #endregion

        #region Methods

        public override string ToString() { return value; }

        #endregion

    }
}
