using System.ComponentModel.DataAnnotations;

namespace GYMWeb.ViewModels
{
    public class MemberEnrollmentDto
    {
        [Required(ErrorMessage = "Member name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string PlanTier { get; set; }

        [Range(500, 25000)]
        public decimal FeeAmount { get; set; }
    }
}
