using System;
using System.Linq;
using System.Threading.Tasks;
using GYMWeb.Model;

namespace GYMWeb.Data
{
    public static class SampleDataSeeder
    {
        public static async Task SeedAsync(GYMWebContext context)
        {
            if (!context.Admin.Any())
            {
                context.Admin.Add(new Admin { Name = "admin", Password = "admin" });
            }

            if (!context.Employee.Any())
            {
                context.Employee.AddRange(
                    new Employee { Name = "Karim Coach", Designation = "Head Fitness Trainer", Email = "karim@gym.local", Phone = "01811000001", Salary = "35000" },
                    new Employee { Name = "Nusrat Nutrition", Designation = "Dietitian", Email = "nusrat@gym.local", Phone = "01811000002", Salary = "30000" }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
