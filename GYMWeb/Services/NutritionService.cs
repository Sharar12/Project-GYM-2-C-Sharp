using System;
using GYMWeb.Model;

namespace GYMWeb.Services
{
    public class NutritionService
    {
        public DietaryPlan CalculateMacros(int memberId, string goal, int targetCalories)
        {
            // Standard fitness split
            int protein = (int)((targetCalories * 0.30) / 4);
            int carbs = (int)((targetCalories * 0.45) / 4);
            int fat = (int)((targetCalories * 0.25) / 9);

            return new DietaryPlan
            {
                MemberId = memberId,
                Goal = goal,
                DailyCalorieTarget = targetCalories,
                ProteinGrams = protein,
                CarbsGrams = carbs,
                FatGrams = fat,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
