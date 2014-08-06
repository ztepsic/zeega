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
            Console.WriteLine("UTC time: {0}", utcTime);

            // Act
            DateTime result = changeStamp.GetCreatedOn(TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            Console.WriteLine("Central European Standard Time: {0}", result);
            Console.WriteLine("Daylight saving time: {0}", result.IsDaylightSavingTime());
            

            // Assert
            Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
            TimeSpan expectedTimeSpan = result.IsDaylightSavingTime() ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.AreEqual(expectedTimeSpan, result-utcTime);

        }

        [Test]
        public void GetUpdatedOn_WithTimeZone_UpdatedOnInRequestedTimeZone() {
            // Arrange
            DateTime utcTime = DateTime.UtcNow;
            ChangeStamp changeStamp = new ChangeStamp(utcTime);
            Console.WriteLine("UTC time: {0}", utcTime);

            // Act
            DateTime result = changeStamp.GetUpdatedOn(TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            Console.WriteLine("Result CEST: {0}", result);
            Console.WriteLine("Result CEST is DST: {0}", result.IsDaylightSavingTime());
            Console.WriteLine("Kind: {0}", result.Kind);
            var cest = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var adjRules = cest.GetAdjustmentRules()[0];
            Console.WriteLine("CEST support DST: {0}", cest.SupportsDaylightSavingTime);
            Console.WriteLine("CEST DST delta: {0}", adjRules.DaylightDelta);
            Console.WriteLine("CEST DST start-end: {0}.{1}-{2}.{3}", adjRules.DaylightTransitionStart.Day, adjRules.DaylightTransitionStart.Month, adjRules.DaylightTransitionEnd.Day, adjRules.DaylightTransitionEnd.Month);
            Console.WriteLine("Local: {0}", TimeZoneInfo.Local);
            Console.WriteLine("Local support DST: {0}", TimeZoneInfo.Local.SupportsDaylightSavingTime);
            


            // Assert
            Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
            TimeSpan expectedTimeSpan = result.IsDaylightSavingTime() ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.AreEqual(expectedTimeSpan, result - utcTime);

        }

    }
}
