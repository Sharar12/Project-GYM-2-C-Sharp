using System.Threading.Tasks;

namespace GYMWeb.Services
{
    public interface ILockerManagementService
    {
        Task<bool> AssignLockerAsync(int lockerNum, int memberId, int months);
        Task<bool> ReleaseLockerAsync(int lockerNum);
    }
}
