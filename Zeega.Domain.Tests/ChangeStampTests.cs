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
            Console.WriteLine("UTC time: {0}", utcTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var adjusmentRuleOfTimeZone = timeZoneInfo.GetAdjustmentRules()[0];

            // Act
            DateTime result = changeStamp.GetUpdatedOn(timeZoneInfo);
            Console.WriteLine("Result CEST: {0}", result);
            Console.WriteLine("Result CEST is DST: {0}", result.IsDaylightSavingTime());
            Console.WriteLine("Result CEST is DST: {0}", timeZoneInfo.IsDaylightSavingTime(result));
            Console.WriteLine("Kind: {0}", result.Kind);
            
            
            Console.WriteLine("CEST support DST: {0}", timeZoneInfo.SupportsDaylightSavingTime);
            Console.WriteLine("CEST DST delta: {0}", adjusmentRuleOfTimeZone.DaylightDelta);
            Console.WriteLine("CEST DST start-end: {0}.{1}-{2}.{3}", adjusmentRuleOfTimeZone.DaylightTransitionStart.Day, adjusmentRuleOfTimeZone.DaylightTransitionStart.Month, adjusmentRuleOfTimeZone.DaylightTransitionEnd.Day, adjusmentRuleOfTimeZone.DaylightTransitionEnd.Month);
            Console.WriteLine("Local: {0}", TimeZoneInfo.Local);
            Console.WriteLine("Local support DST: {0}", TimeZoneInfo.Local.SupportsDaylightSavingTime);
            


            // Assert
            Assert.AreEqual(DateTimeKind.Unspecified, result.Kind);
            TimeSpan expectedTimeSpan = timeZoneInfo.IsDaylightSavingTime(result) ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.AreEqual(expectedTimeSpan, result - utcTime);

        }

    }
}
