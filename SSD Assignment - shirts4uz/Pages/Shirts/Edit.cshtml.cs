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

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    public class EditModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public EditModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shirt Shirt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shirt = await _context.Shirt.FirstOrDefaultAsync(m => m.ID == id);

            if (Shirt == null)
            {
                return NotFound();
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

            _context.Attach(Shirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShirtExists(Shirt.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShirtExists(int id)
        {
            return _context.Shirt.Any(e => e.ID == id);
        }
    }
}
