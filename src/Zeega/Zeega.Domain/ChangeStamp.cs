using System;

namespace Zeega.Domain {
    /// <summary>
    /// The value object that represents change stamp data.
    /// Data includes creation and change dates.
    /// </summary>
    public class ChangeStamp {

        #region Fields and Properties

        /// <summary>
        /// Creation date and time in UTC
        /// </summary>
        private readonly DateTime createdOn;

        /// <summary>
        /// Gets creation date and time in UTC
        /// </summary>
        public DateTime CreatedOn { get { return createdOn; } }

        /// <summary>
        /// Update date and time in UTC
        /// </summary>
        private DateTime updatedOn;

        /// <summary>
        /// Gets update date and time in UTC
        /// </summary>
        public DateTime UpdatedOn { get { return updatedOn; }}

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor.
        /// </summary>
        private ChangeStamp() { }

        /// <summary>
        /// Creates instance of ChangeStamp class based on creation date
        /// </summary>
        /// <param name="createdOn">Date of creation</param>
        public ChangeStamp(DateTime createdOn) {
            this.createdOn = createdOn.ToUniversalTime();
            updatedOn = createdOn.ToUniversalTime();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets UpdatedOn to provided date in UTC.
        /// </summary>
        /// <param name="updatedOn">Date to witch UpdatedOn will be set in UTC.</param>
        public void SetUpdatedOn(DateTime updatedOn) { this.updatedOn = updatedOn.ToUniversalTime(); }

        /// <summary>
        /// Sets UpdatedOn to current date in UTC.
        /// </summary>
        public void SetUpdatedOn() { SetUpdatedOn(DateTime.UtcNow); }

        /// <summary>
        /// Gets UpdatedOn date in local date
        /// </summary>
        /// <returns>UpdatedOn date in local date</returns>
        public DateTime GetUpdatedOn() { return updatedOn.ToLocalTime(); }

        /// <summary>
        /// Gets UpdatedOn date in requested time zone
        /// </summary>
        /// <param name="timeZoneInfo">Time zone in which we want UpdatedOn date</param>
        /// <returns>UpdatedOn date in requested time zone</returns>
        public DateTime GetUpdatedOn(TimeZoneInfo timeZoneInfo) {
            return TimeZoneInfo.ConvertTimeFromUtc(createdOn, timeZoneInfo);
        }

        /// <summary>
        /// Gets CreatedOn date in local date
        /// </summary>
        /// <returns>CreatedOn date in local date</returns>
        public DateTime GetCreatedOn() { return createdOn.ToLocalTime(); }

        /// <summary>
        /// Gets CreatedOn date in requested time zone
        /// </summary>
        /// <param name="timeZoneInfo">Time zone in which we want CreatedOn date</param>
        /// <returns>CreatedOn date in reqested time zone</returns>
        public DateTime GetCreatedOn(TimeZoneInfo timeZoneInfo) {
            return TimeZoneInfo.ConvertTimeFromUtc(createdOn, timeZoneInfo);
        }

        #endregion

    }
}
