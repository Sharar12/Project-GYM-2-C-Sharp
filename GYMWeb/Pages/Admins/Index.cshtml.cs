using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Data;
using GYMWeb.Model;

namespace GYMWeb.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly GYMWeb.Data.GYMWebContext _context;

        public IndexModel(GYMWeb.Data.GYMWebContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Admin = await _context.Admin.ToListAsync();
        }
    }
}
