using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    public class DetailsModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public DetailsModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

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
    }
}
