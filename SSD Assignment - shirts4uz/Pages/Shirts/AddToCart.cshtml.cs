using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    [Authorize]
    public class AddToCartModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public AddToCartModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shirt Shirt { get; set; }

        [BindProperty]
        public Cart Cart { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Shirt = await _context.Shirt.FirstOrDefaultAsync(m => m.ID == id);

            if (Shirt == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Cart.ShirtID = Shirt.ID.ToString();
            Cart.UserEmail = User.Identity.Name.ToString();
            Cart.ShirtName = Shirt.Name;
            Cart.TtlPrice = Shirt.Price * Cart.Quantity;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["message"] = "Added to Cart";
            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();


            _context.Cart.Add(Cart);

            return RedirectToPage("./Index");
        }
    }
}
