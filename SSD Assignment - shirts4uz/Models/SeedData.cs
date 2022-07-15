using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSD_Assignment___shirts4uz.Data;

namespace SSD_Assignment___shirts4uz.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SSD_Assignment___shirts4uzContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SSD_Assignment___shirts4uzContext>>()))
            {
                // Look for any movies.
                if (context.Shirt.Any())
                {
                    return;   // DB has been seeded
                }
                context.Shirt.AddRange(
                    new Shirt
                    {
                        Name = "Middle Gauge Knitted Crew Neck Vest",
                        Color = "Beige",
                        Size = "L",
                        Description = "Loosely knit for a slightly chunky look. Easy care fabric is an added plus.",
                        Price = 29.90M,
                        Category = "Mens Shirts",
                        PhotoPath = "crewneckvest.webp"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
