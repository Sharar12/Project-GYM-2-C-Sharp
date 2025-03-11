namespace GYMWeb.ViewModels
{
    public class GymFacilityStatsViewModel
    {
        public int TotalActiveMembers { get; set; }
        public int TotalTrainers { get; set; }
        public int RentedLockers { get; set; }
        public decimal TotalCollectedDues { get; set; }
        public int TodayAttendanceCount { get; set; }
    }
}
