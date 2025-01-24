using System;

namespace GYMWeb.Services
{
    public class TrainerAvailabilityService
    {
        public bool IsSlotAvailable(int trainerId, DayOfWeek day, TimeSpan time)
        {
            return trainerId > 0;
        }
    }
}
