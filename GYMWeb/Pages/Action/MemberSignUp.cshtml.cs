using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Action
{
    public class MemberSignupModel : PageModel
    {
        private readonly GYMWebContext _context;

        public MemberSignupModel(GYMWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; } = new Member();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            // Redirect to SignIn page after signup
            return RedirectToPage("SignIn");
        }
    }
}
