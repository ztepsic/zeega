using Zed.Domain;

namespace Zeega.Domain.GameModel {
    /// <summary>
    /// Enumeration that represent device types
    /// </summary>
    public class DeviceTypeSupport : ValueObject {

        #region Fields and Properties

        /// <summary>
        /// Indicates if a desktop device is supported
        /// </summary>
        private readonly bool isDesktopSupported;

        /// <summary>
        /// Gets an indicator which indicates if a desktop device is supported
        /// </summary>
        public bool IsDesktopSupported { get { return isDesktopSupported; } }

        /// <summary>
        /// Indicates if a mobile device is supported
        /// </summary>
        private readonly bool isMobileSupported;

        /// <summary>
        /// Gets an indicator which indicates if a mobile device is supported
        /// </summary>
        public bool IsMobileSupported { get { return isMobileSupported; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor created DeviceTypeSupport instance
        /// </summary>
        private DeviceTypeSupport() { }

        /// <summary>
        /// Creates value object that represetns device type support
        /// </summary>
        /// <param name="isDesktopSupported">Indicates if a desktop device is supported</param>
        /// <param name="isMobileSupported">Indicates if a mobile device is supported</param>
        public DeviceTypeSupport(bool isDesktopSupported, bool isMobileSupported) {
            this.isDesktopSupported = isDesktopSupported;
            this.isMobileSupported = isMobileSupported;
        }

        #endregion

    }
}
