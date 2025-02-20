using System.Threading.Tasks;

namespace GYMWeb.Services
{
    public interface IAttendanceLoggerService
    {
        Task<bool> LogCheckInAsync(int memberId, string method);
        Task<bool> LogCheckOutAsync(int memberId);
    }
}
