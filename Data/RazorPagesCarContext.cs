using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RazorPagesCar.Models;



namespace RazorPagesCar.Models
{
    public class RazorPagesCarContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public RazorPagesCarContext (DbContextOptions<RazorPagesCarContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

     
                 
        }



        public DbSet<RazorPagesCar.Models.Car> Car { get; set; }
        public DbSet<RazorPagesCar.Models.Customer> Customers { get; set; }

        public DbSet<RazorPagesCar.Models.AuditRecord> AuditRecords { get; set; }
    }
}
