using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;

namespace GYMWeb.Services
{
    public class MemberNotificationService
    {
        private readonly GYMWebContext _context;

        public MemberNotificationService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetExpiringMemberAlertsAsync(int daysWindow)
        {
            var threshold = DateTime.UtcNow.AddDays(daysWindow);
            var members = await _context.Member
                .Where(m => m.ExpireDate <= threshold && m.ExpireDate >= DateTime.UtcNow)
                .ToListAsync();

            return members.Select(m => $"Notification: Member {m.Name} pass expires on {m.ExpireDate:yyyy-MM-dd}.").ToList();
        }
    }
}
