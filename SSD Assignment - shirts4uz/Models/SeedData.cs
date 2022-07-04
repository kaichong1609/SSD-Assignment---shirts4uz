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
                        Name = "Long Sleeve Flannel",
                        Color = "Red and Black",
                        Size = "XL",
                        Description = "A soft, warm classic shirt with an updated design that makes a great outer layer.",
                        Price = 21.90M,
                        ListDate = DateTime.Parse("2022-7-4"),
                        Category = "Mens Long Sleeve",
                        Review = "4.2/5"
                    },

                    new Shirt
                    {
                        Name = "Cotton Cropped Short Sleeve Blouse",
                        Color = "Purple",
                        Size = "XS",
                        Description = "Distinctive cropped cut. This blouse makes a style statement all on its own.",
                        Price = 29.90M,
                        ListDate = DateTime.Parse("2022-6-27"),
                        Category = "Womens Shirts and Blouses",
                        Review = "4.1/5"

                    },

                    new Shirt
                    {
                        Name = "Cotton Long Sleeve Shirt",
                        Color = "Navy",
                        Size = "M",
                        Description = "A premium cotton shirt in a loose-fitting silhouette. Featuring deep slits in the hem.",
                        Price = 33.90M,
                        ListDate = DateTime.Parse("2022-6-28"),
                        Category = "Womens Shirts and Blouses",
                        Review = "3.9/5"
                    },

                    new Shirt
                    {
                        Name = "Cotton Gathered Sleeveless Blouse",
                        Color = "Yellow",
                        Size = "XS",
                        Description = "100% cotton with a light, airy texture. Gathered and tiered silhouette.",
                        Price = 29.90M,
                        ListDate = DateTime.Parse("2022-5-17"),
                        Category = "Womens Shirts and Blouses",
                        Review = "4.6/5"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
