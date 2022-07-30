using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;
using Microsoft.AspNetCore.Authorization;


namespace SSD_Assignment___shirts4uz.Pages.CartItems
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public EditModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart.FirstOrDefaultAsync(m => m.ID == id);
            

            if (Cart == null)
            {
                return NotFound();
            }
            if (Cart.UserEmail == User.Identity.Name)
            {
                Cart.TtlPrice = Cart.TtlPrice / Cart.Quantity;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Cart.TtlPrice = Cart.TtlPrice * Cart.Quantity;
            _context.Attach(Cart).State = EntityState.Modified;
            TempData["msg"] = "Quantity Changed";
            await _context.SaveChangesAsync();
            return RedirectToPage("./ViewCart");
        }

    }
}
