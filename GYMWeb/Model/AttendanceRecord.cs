using System;
using System.ComponentModel.DataAnnotations;

namespace GYMWeb.Model
{
    public class AttendanceRecord
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string AccessMethod { get; set; } // RFID, QR, Manual
        public string GateId { get; set; }
    }
}
