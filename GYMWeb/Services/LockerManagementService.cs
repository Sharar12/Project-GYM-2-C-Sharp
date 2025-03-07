using System;
using System.Threading.Tasks;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public class LockerManagementService : ILockerManagementService
    {
        private readonly GYMWebContext _context;

        public LockerManagementService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignLockerAsync(int lockerNum, int memberId, int months)
        {
            var locker = await _context.Set<LockerRental>().FindAsync(lockerNum);
            if (locker == null || locker.IsRented) return false;

            locker.OccupantMemberId = memberId;
            locker.IsRented = true;
            locker.RentedUntil = DateTime.UtcNow.AddMonths(months);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReleaseLockerAsync(int lockerNum)
        {
            var locker = await _context.Set<LockerRental>().FindAsync(lockerNum);
            if (locker == null) return false;

            locker.OccupantMemberId = null;
            locker.IsRented = false;
            locker.RentedUntil = null;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
