using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Action
{
    public class MDetailsModel : PageModel
    {
        private readonly GYMWebContext _context;

        public MDetailsModel(GYMWebContext context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
            {
                return NotFound();
            }

            return Page();
        }


        // Calculate BMI
        public double CalculateBMI()
        {
            if (Member.weight <= 0 || Member.height <= 0) return 0;
            double heightInMeters = Member.height / 100.0; // Convert cm to meters
            return Member.weight / (heightInMeters * heightInMeters);
        }

        // Calculate Body Fat Percentage (using BMI method)
        public double CalculateBodyFat()
        {
            if (Member.gender.ToLower() == "male")
            {
                return (1.20 * CalculateBMI()) + (0.23 * Member.age) - 16.2;
            }
            else
            {
                return (1.20 * CalculateBMI()) + (0.23 * Member.age) - 5.4;
            }
        }

        // Calculate Lean Body Mass
        public double CalculateLeanBodyMass()
        {
            return Member.weight * (1 - (CalculateBodyFat() / 100));
        }

        // Calculate Basal Metabolic Rate (BMR)
        public double CalculateBMR()
        {
            if (Member.gender.ToLower() == "male")
            {
                return 88.36 + (13.4 * Member.weight) + (4.8 * Member.height) - (5.7 * Member.age);
            }
            else
            {
                return 447.6 + (9.2 * Member.weight) + (3.1 * Member.height) - (4.3 * Member.age);
            }
        }

        // Calculate Daily Caloric Needs (BMR * activity multiplier)
        public double CalculateCaloricNeeds()
        {
            double activityMultiplier = 1.55; // Assume moderate activity level
            return CalculateBMR() * activityMultiplier;
        }

        // Health Comment based on BMI
        public string GetHealthComment()
        {
            double bmi = CalculateBMI();
            if (bmi < 18.5) return "Underweight - Consider a balanced diet and strength training.";
            if (bmi >= 18.5 && bmi < 24.9) return "Healthy weight - Maintain your current lifestyle!";
            if (bmi >= 25 && bmi < 29.9) return "Overweight - Consider increasing activity levels.";
            return "Obese - A structured exercise and diet plan is recommended.";
        }
    }
}
