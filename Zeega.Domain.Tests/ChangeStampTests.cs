using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Zeega.Domain.Tests {
    [TestFixture]
    public class ChangeStampTests {

        [Test]
        public void Ctr_ValidDateParams_DateValuesInUtc() {
            // Arrange
            DateTime localTime = DateTime.Now;
            DateTime utcTime = localTime.ToUniversalTime();

            // Act
            ChangeStamp changeStamp = new ChangeStamp(localTime);

            // Assert
            Assert.AreEqual(utcTime, changeStamp.CreatedOn);
            Assert.AreEqual(DateTimeKind.Utc, changeStamp.CreatedOn.Kind);

            Assert.AreEqual(utcTime, changeStamp.UpdatedOn);
            Assert.AreEqual(DateTimeKind.Utc, changeStamp.UpdatedOn.Kind);

        }

        [Test]
        public void GetCreatedOn_WithTimeZone_CreatedOnInRequestedTimeZone() {
            // Arrange
            DateTime utcTime = DateTime.UtcNow;
            ChangeStamp changeStamp = new ChangeStamp(utcTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Act
            DateTime result = changeStamp.GetCreatedOn(timeZoneInfo);
            

            // Assert
            Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
            TimeSpan expectedTimeSpan = timeZoneInfo.IsDaylightSavingTime(result) ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.AreEqual(expectedTimeSpan, result-utcTime);

        }

        [Test]
        public void GetUpdatedOn_WithTimeZone_UpdatedOnInRequestedTimeZone() {
            // Arrange
            DateTime utcTime = DateTime.UtcNow;
            ChangeStamp changeStamp = new ChangeStamp(utcTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Act
            DateTime result = changeStamp.GetUpdatedOn(timeZoneInfo);

            // Assert
            Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
            TimeSpan expectedTimeSpan = timeZoneInfo.IsDaylightSavingTime(result) ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.AreEqual(expectedTimeSpan, result - utcTime);

        }

    }
}
