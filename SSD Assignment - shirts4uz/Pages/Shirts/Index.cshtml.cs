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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    public class IndexModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public IndexModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        public IList<Shirt> ShirtList { get;set; }
        [BindProperty(SupportsGet = true)]

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string SearchString { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ShirtCategory { get; set; }
        [BindProperty]
        public Shirt Shirt { get; set; }
        
        public async Task OnGetAsync()
        {
            IQueryable<string> categoryQuery = from m in _context.Shirt
                                            orderby m.Category
                                            select m.Category;
            var shirts = from m in _context.Shirt
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                shirts = shirts.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ShirtCategory))
            {
                shirts = shirts.Where(x => x.Category == ShirtCategory);
            }
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            ShirtList = await shirts.ToListAsync();
        }
        /*public async Task<IActionResult> OnPostAsync()
        {
            CartItems.UserEmail = User.Identity.Name.ToString();
            CartItems.ShirtID = Shirt.ID.ToString();
            CartItems.price =Shirt.Price;
            CartItems.ShirtName = Shirt.Name.ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.CartItems.Add(CartItems);
            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                TempData["message"] = "Added to Cart";
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "New Cart Item Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyShirtFieldID = CartItems.ID.ToString();
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }

            _context.CartItems.Add(CartItems);

            return RedirectToPage("./Index");
        }*/
    }
}
