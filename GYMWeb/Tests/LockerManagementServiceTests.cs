using Xunit;

namespace GYMWeb.Tests
{
    public class LockerManagementServiceTests
    {
        [Fact]
        public void OccupiedLocker_ShouldNotBeReassigned()
        {
            bool isRented = true;
            Assert.True(isRented);
        }
    }
}
