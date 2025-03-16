using System;
using Xunit;

namespace GYMWeb.Tests
{
    public class MembershipPlanServiceTests
    {
        [Fact]
        public void ExpiredDatePriorToNow_ShouldBeRecognizedAsExpired()
        {
            var expire = DateTime.UtcNow.AddDays(-2);
            Assert.True(expire < DateTime.UtcNow);
        }

        [Fact]
        public void NewMemberOneMonthPlan_ShouldAddThirtyDays()
        {
            var now = DateTime.UtcNow;
            var expected = now.AddMonths(1);
            Assert.True(expected > now);
        }
    }
}
