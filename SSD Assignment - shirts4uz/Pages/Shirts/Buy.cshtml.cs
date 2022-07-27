using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    [Authorize]
    public class BuyModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public BuyModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        public string Hash(string ccnum)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: ccnum,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;

        }

        [BindProperty]
        public Shirt Shirt { get; set; }
        [BindProperty]
        public Order Order { get; set; }

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
            Order.ShirtID = Shirt.ID.ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order.CCNum = Hash(Order.CCNum);
            _context.Order.Add(Order);
            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {   
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add Order Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyShirtFieldID = Order.ID.ToString();
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }

            _context.Order.Add(Order);
            
            return RedirectToPage("./Index");
        }
    }
}
