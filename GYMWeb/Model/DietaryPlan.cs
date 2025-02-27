using System;
using System.ComponentModel.DataAnnotations;

namespace GYMWeb.Model
{
    public class DietaryPlan
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Goal { get; set; } // Weight Loss, Muscle Gain, Endurance
        public int DailyCalorieTarget { get; set; }
        public int ProteinGrams { get; set; }
        public int CarbsGrams { get; set; }
        public int FatGrams { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
