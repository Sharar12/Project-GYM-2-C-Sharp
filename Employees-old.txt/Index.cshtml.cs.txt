using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly GYMWeb.Data.GYMWebContext _context;

        public IndexModel(GYMWeb.Data.GYMWebContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
        }

        // Handle DELETE request
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
