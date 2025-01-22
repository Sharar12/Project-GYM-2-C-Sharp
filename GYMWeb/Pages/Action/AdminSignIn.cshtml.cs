using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GYMWeb.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GYMWeb.Pages.Action
{
    public class AdminSignInModel : PageModel
    {
        private readonly GYMWebContext _context;

        public AdminSignInModel(GYMWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string userName { get; set; }

        [BindProperty]
        public string password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var admin = _context.Admin
                .FirstOrDefault(a => a.userName == userName && a.password == password);

            if (admin != null)
            {
                return RedirectToPage("/Admins/Details", new { id = admin.Id }); // Redirect to Admin Details page
            }
            else
            {
                ErrorMessage = "Invalid Username or Password.";
                return Page();
            }
        }
    }
}
