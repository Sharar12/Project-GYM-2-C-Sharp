using System.Threading.Tasks;

namespace GYMWeb.Services
{
    public interface ITrainerDispatchService
    {
        Task<bool> AssignTrainerToMemberAsync(int memberId, int employeeId);
        Task<int> GetTrainerActiveMemberCountAsync(int employeeId);
    }
}
