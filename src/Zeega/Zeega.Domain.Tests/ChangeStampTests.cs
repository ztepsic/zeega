using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Zeega.Domain.Tests
{
    [TestFixture]
    public class ChangeStampTests
    {

        [Test]
        public void Ctr_ValidDateParams_DateValuesInUtc()
        {
            // Arrange
            DateTime localTime = DateTime.Now;
            DateTime utcTime = localTime.ToUniversalTime();

            // Act
            ChangeStamp changeStamp = new ChangeStamp(localTime);

            // Assert
            Assert.That(changeStamp.CreatedOn, Is.EqualTo(utcTime));
            Assert.That(changeStamp.CreatedOn.Kind, Is.EqualTo(DateTimeKind.Utc));

            Assert.That(changeStamp.UpdatedOn, Is.EqualTo(utcTime));
            Assert.That(changeStamp.UpdatedOn.Kind, Is.EqualTo(DateTimeKind.Utc));

        }

        [Test]
        public void GetCreatedOn_WithTimeZone_CreatedOnInRequestedTimeZone()
        {
            // Arrange
            DateTime utcTime = DateTime.UtcNow;
            ChangeStamp changeStamp = new ChangeStamp(utcTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Act
            DateTime result = changeStamp.GetCreatedOn(timeZoneInfo);


            // Assert
            Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Unspecified));
            TimeSpan expectedTimeSpan = timeZoneInfo.IsDaylightSavingTime(result) ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
            Assert.That(result - utcTime, Is.EqualTo(expectedTimeSpan));

        }

        [Test]
        public void GetUpdatedOn_WithTimeZone_UpdatedOnInRequestedTimeZone()
        {
            // Arrange
            DateTime utcTime = DateTime.UtcNow;
            ChangeStamp changeStamp = new ChangeStamp(utcTime);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Act
            DateTime result = changeStamp.GetUpdatedOn(timeZoneInfo);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Unspecified));
                TimeSpan expectedTimeSpan = timeZoneInfo.IsDaylightSavingTime(result) ? TimeSpan.FromHours(2) : TimeSpan.FromHours(1);
                Assert.That(result - utcTime, Is.EqualTo(expectedTimeSpan));
            });

        }

    }
}
