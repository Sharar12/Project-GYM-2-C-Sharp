using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Action
{
    public class EmployeeSignUpModel : PageModel
    {
        private readonly GYMWebContext _context;

        public EmployeeSignUpModel(GYMWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            // Redirect to SignIn page after signup
            return RedirectToPage("SignIn");
        }
    }
}
