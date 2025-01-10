using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYMWeb.Model;

namespace GYMWeb.Data
{
    public class GYMWebContext : DbContext
    {
        public GYMWebContext (DbContextOptions<GYMWebContext> options)
            : base(options)
        {
        }

        public DbSet<GYMWeb.Model.Member> Member { get; set; } = default!;
        public DbSet<GYMWeb.Model.Employee> Employee { get; set; } = default!;
        public DbSet<GYMWeb.Model.Admin> Admin { get; set; } = default!;
    }
}
