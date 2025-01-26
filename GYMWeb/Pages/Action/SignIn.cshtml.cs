using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Action
{
    public class SignInModel : PageModel
    {
        private readonly GYMWebContext _context;

        public SignInModel(GYMWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string UserType { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UserType == "Member")
            {
                var member = _context.Member.FirstOrDefault(m => m.email == Email && m.password == Password);
                if (member == null)
                {
                    ErrorMessage = "Invalid Member email or password.";
                    return Page();
                }

                // Redirect to Member Details page with the ID
                return RedirectToPage("MemberDashboard", new { id = member.Id });
            }
            else if (UserType == "Employee")
            {
                var employee = _context.Employee.FirstOrDefault(e => e.email == Email && e.password == Password);
                if (employee == null)
                {
                    ErrorMessage = "Invalid Employee email or password.";
                    return Page();
                }

                // Redirect to Employee Details page with the ID
                return RedirectToPage("EmployeeDashboard", new { id = employee.Id });
            }

            ErrorMessage = "Invalid User Type selected.";
            return Page();
        }
    }
}
