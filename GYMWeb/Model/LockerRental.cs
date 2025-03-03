using System;
using System.ComponentModel.DataAnnotations;

namespace GYMWeb.Model
{
    public class LockerRental
    {
        [Key]
        public int LockerNumber { get; set; }
        public int? OccupantMemberId { get; set; }
        public bool IsRented { get; set; }
        public DateTime? RentedUntil { get; set; }
        public decimal MonthlyRate { get; set; }
    }
}
