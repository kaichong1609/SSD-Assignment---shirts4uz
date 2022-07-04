using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Models;

namespace SSD_Assignment___shirts4uz.Data
{
    public class SSD_Assignment___shirts4uzContext : DbContext
    {
        public SSD_Assignment___shirts4uzContext (DbContextOptions<SSD_Assignment___shirts4uzContext> options)
            : base(options)
        {
        }

        public DbSet<SSD_Assignment___shirts4uz.Models.Shirt> Shirt { get; set; }
    }
}
