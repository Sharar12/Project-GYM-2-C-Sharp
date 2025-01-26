using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Action
{
    public class MemberListModel : PageModel
    {
        private readonly GYMWebContext _context;

        public MemberListModel(GYMWebContext context)
        {
            _context = context;
        }

        public List<Member> Members { get; set; } = new List<Member>();
        public int EmployeeId { get; private set; }

        public async Task OnGetAsync(int? employeeId)
        {
            if (employeeId.HasValue)
            {
                EmployeeId = employeeId.Value; // Store EmployeeId for returning
            }
            Members = await _context.Member.ToListAsync();
        }

        // Calculate BMI
        public double CalculateBMI(double weight, double height)
        {
            if (weight <= 0 || height <= 0) return 0;
            double heightInMeters = height / 100.0; // Convert cm to meters
            return weight / (heightInMeters * heightInMeters);
        }

        // Calculate Body Fat Percentage (using BMI method)
        public double CalculateBodyFat(string gender, double bmi, int age)
        {
            if (gender.ToLower() == "male")
            {
                return (1.20 * bmi) + (0.23 * age) - 16.2;
            }
            else
            {
                return (1.20 * bmi) + (0.23 * age) - 5.4;
            }
        }

        // Calculate Lean Body Mass
        public double CalculateLeanBodyMass(double weight, double bodyFatPercentage)
        {
            return weight * (1 - (bodyFatPercentage / 100));
        }

        // Calculate Basal Metabolic Rate (BMR)
        public double CalculateBMR(string gender, double weight, double height, int age)
        {
            if (gender.ToLower() == "male")
            {
                return 88.36 + (13.4 * weight) + (4.8 * height) - (5.7 * age);
            }
            else
            {
                return 447.6 + (9.2 * weight) + (3.1 * height) - (4.3 * age);
            }
        }

        // Calculate Daily Caloric Needs (BMR * activity multiplier)
        public double CalculateCaloricNeeds(double bmr)
        {
            double activityMultiplier = 1.55; // Assume moderate activity level
            return bmr * activityMultiplier;
        }

        // Generate Health Comment
        public string GetHealthComment(double bmi)
        {
            if (bmi < 18.5) return "Underweight - Consider a balanced diet and strength training.";
            if (bmi >= 18.5 && bmi < 24.9) return "Healthy weight - Maintain your current lifestyle!";
            if (bmi >= 25 && bmi < 29.9) return "Overweight - Consider increasing activity levels.";
            return "Obese - A structured exercise and diet plan is recommended.";
        }
    }
}
