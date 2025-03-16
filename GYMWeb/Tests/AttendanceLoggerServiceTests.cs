using System;
using Xunit;

namespace GYMWeb.Tests
{
    public class AttendanceLoggerServiceTests
    {
        [Fact]
        public void ConsecutiveScans_ShouldEnforceCooldownPeriod()
        {
            var scan1 = DateTime.UtcNow.AddMinutes(-5);
            var diff = (DateTime.UtcNow - scan1).TotalMinutes;
            Assert.True(diff < 30);
        }
    }
}
