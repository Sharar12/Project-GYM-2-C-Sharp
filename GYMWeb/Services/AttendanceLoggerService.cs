using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public class AttendanceLoggerService : IAttendanceLoggerService
    {
        private readonly GYMWebContext _context;

        public AttendanceLoggerService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<bool> LogCheckInAsync(int memberId, string method)
        {
            var member = await _context.Member.FindAsync(memberId);
            if (member == null || member.Status != "Active" || member.ExpireDate < DateTime.UtcNow)
                return false;

            var log = new AttendanceRecord
            {
                MemberId = memberId,
                CheckInTime = DateTime.UtcNow,
                AccessMethod = method ?? "QR",
                GateId = "MainEntrance-Gate1"
            };

            _context.Set<AttendanceRecord>().Add(log);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LogCheckOutAsync(int memberId)
        {
            var openLog = await _context.Set<AttendanceRecord>()
                .Where(a => a.MemberId == memberId && a.CheckOutTime == null)
                .OrderByDescending(a => a.CheckInTime)
                .FirstOrDefaultAsync();

            if (openLog == null) return false;

            openLog.CheckOutTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
