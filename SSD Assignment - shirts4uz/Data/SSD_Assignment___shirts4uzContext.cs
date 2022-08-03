using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace SSD_Assignment___shirts4uz.Data
{
    public class SSD_Assignment___shirts4uzContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SSD_Assignment___shirts4uzContext (DbContextOptions<SSD_Assignment___shirts4uzContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Shirt>().ToTable("Shirt");
        }

        public DbSet<SSD_Assignment___shirts4uz.Models.Shirt> Shirt { get; set; }
        public DbSet<SSD_Assignment___shirts4uz.Models.AuditRecord> AuditRecords { get; set; }
        public DbSet<SSD_Assignment___shirts4uz.Models.Feedback> Feedback { get; set; }
        public DbSet<SSD_Assignment___shirts4uz.Models.Cart> Cart { get; set; }
        public DbSet<SSD_Assignment___shirts4uz.Models.Delivery> Delivery { get; set; }


    }
}
