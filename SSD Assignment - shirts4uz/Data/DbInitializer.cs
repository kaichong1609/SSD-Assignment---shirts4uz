using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;

namespace SSD_Assignment___shirts4uz.Data
{
    public class DbInitializer
    {
        public static void Initialize(SSD_Assignment___shirts4uzContext context)
        {
            context.Database.EnsureCreated();

            if (context.Shirt.Any())
            {
                return; //DB has been seeded
            }

            var shirts = new Shirt[]
            {
                new Shirt{Name = "Sweat Pullover Hoodie", Color="Black", Size="XL", Description="Now in a smoother and more durable sweat fabric",
                    Price=40.90M, Category = "Mens Sweaters", PhotoPath="pulloverhoodie.webp"},
                new Shirt{Name = "Ultra Light Pants", Color="Navy", Size="L", Description="Incredibly lightweight and comfortable",
                    Price=50.90M, Category = "Mens Pants", PhotoPath="lightpants.webp"},
                new Shirt{Name = "Ultra Light Shorts", Color="Black", Size="XL", Description="Surprisingly lightweight high performance shorts",
                    Price=28.90M, Category = "Mens Shorts", PhotoPath="lightshorts.webp"},
                new Shirt{Name = "High Rise Cropped Leggings ", Color="Blue", Size="S", Description="Updated design for easy styling as pants or leggings",
                    Price=39.90M, Category = "Womens Pants", PhotoPath="croppedleggings.webp"},
                new Shirt{Name = "Over Shirt Jacket", Color="Olive", Size="XXL", Description="Relaxed cut that is perfect for layering",
                    Price=52.90M, Category = "Mens Sweaters", PhotoPath="jacket.webp"},
                new Shirt{Name = "Short Sleeve Flare Dress", Color="Dark Blue", Size="M", Description="A  lightweight dress with an elegant flare",
                    Price=40.90M, Category = "Womens Dress", PhotoPath="flaredress.webp"},
                new Shirt{Name = "Soft Brushed Long Sleeve Shirt", Color="Brown", Size="XS", Description="Supple fabric and a skipper neckline for an effortless look",
                    Price=39.90M, Category = "Womens Shirt", PhotoPath="softbrushedshirt.webp"},
                new Shirt{Name = "Slim Fit Chino Pants", Color="Gray", Size="L", Description="Now in a more streamlined silhouette",
                    Price=49.90M, Category = "Mens Pants", PhotoPath="chino.webp"},
                new Shirt{Name = "Washed Jersey Easy Shorts", Color="Brown", Size="M", Description="Shorts with a distinctive coarse texture",
                    Price=19.90M, Category = "Mens Shorts", PhotoPath="washedshort.webp"},
                new Shirt{Name = "Stretch Easy Shorts", Color="Gray", Size="XS", Description="Stretch for easy movement",
                    Price=19.90M, Category = "Mens Shorts", PhotoPath="easyshort.webp"},
                new Shirt{Name = "Soft Flannel Long Sleeve Mini Dress", Color="Navy", Size="S", Description="Soft flannel fabric creates an attractive silhouette",
                    Price=59.90M, Category = "Womens Dress", PhotoPath="flanneldress.webp"},
                new Shirt{Name = "Crew Neck Short Sleeve T-Shirt Dress", Color="Green", Size="S", Description="Relaxed fabric and cut",
                    Price=29.90M, Category = "Womens Dress", PhotoPath="tshirtdress.webp" }
            };

            context.Shirt.AddRange(shirts);
            context.SaveChanges();
        }
    }
}
