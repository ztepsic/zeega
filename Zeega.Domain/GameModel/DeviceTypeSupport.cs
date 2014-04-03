using Zed.Core.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Enumeration that represent device types
    /// </summary>
    public class DeviceTypeSupport : ValueObject {

        #region Fields and Properties

        /// <summary>
        /// Indicates if a desktop device is enabled
        /// </summary>
        private readonly bool isDesktopEnabled;

        /// <summary>
        /// Gets an indicator which indicates if a desktop device is enbled
        /// </summary>
        public bool IsDesktopEnabled { get { return isDesktopEnabled; } }

        /// <summary>
        /// Indicates if a mobile device is enabled
        /// </summary>
        private readonly bool isMobileEnabled;

        /// <summary>
        /// Gets an indicator which indicates if a mobile device is enabled
        /// </summary>
        public bool IsMobileEnabled { get { return isMobileEnabled; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates value object that represetns device type support
        /// </summary>
        /// <param name="isDesktopEnabled">Indicates if a desktop device is enabled.</param>
        /// <param name="isMobileEnabled">Indicates if a mobile device is enabled.</param>
        public DeviceTypeSupport(bool isDesktopEnabled, bool isMobileEnabled) {
            this.isDesktopEnabled = isDesktopEnabled;
            this.isMobileEnabled = isMobileEnabled;
        }

        #endregion

    }
}
