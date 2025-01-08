using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GYMWeb.Data
{
    public static class DatabaseHealthChecker
    {
        public static async Task<bool> CanConnectAsync(GYMWebContext context)
        {
            return await context.Database.CanConnectAsync();
        }
    }
}
