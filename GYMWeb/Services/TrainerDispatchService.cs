using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;

namespace GYMWeb.Services
{
    public class TrainerDispatchService : ITrainerDispatchService
    {
        private readonly GYMWebContext _context;

        public TrainerDispatchService(GYMWebContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignTrainerToMemberAsync(int memberId, int employeeId)
        {
            var member = await _context.Member.FindAsync(memberId);
            var employee = await _context.Employee.FindAsync(employeeId);
            if (member == null || employee == null) return false;

            member.TrainerId = employeeId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTrainerActiveMemberCountAsync(int employeeId)
        {
            return await _context.Member
                .CountAsync(m => m.TrainerId == employeeId && m.Status == "Active");
        }
    }
}
