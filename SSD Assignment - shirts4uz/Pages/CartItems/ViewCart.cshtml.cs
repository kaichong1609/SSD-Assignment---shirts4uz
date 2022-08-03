using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace SSD_Assignment___shirts4uz.Pages.CartItems
{
    [Authorize]
    public class ViewCartModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public ViewCartModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Delivery Delivery { get; set; }
        public IList<Cart> CartList { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }

        [StringLength(300, MinimumLength = 1, ErrorMessage = "Please enter valid string."), Required]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Please enter valid string.")]
        public string NameonCard { get; set; }
        [StringLength(300, MinimumLength = 13, ErrorMessage = "Please enter valid string."), Required]
        public string CCNum { get; set; }

        [Range(1, 12, ErrorMessage = "Please enter valid number."), RegularExpression(@"\d{1,2}]*", ErrorMessage = "Please enter valid number."), Required]
        public int ExpMonth { get; set; }
        [Range(2022, 3000, ErrorMessage = "Please enter valid year"), RegularExpression(@"\d{4}]*", ErrorMessage = "Please enter valid year."), Required]
        public int ExpYear { get; set; }
        [Range(100, 999, ErrorMessage = "Please enter a valid CVV"), RegularExpression(@"\d{3}]*", ErrorMessage = "Please enter a valid CVV."), Required]
        public int CVV { get; set; }
        public async Task OnGetAsync()
        {
            CartList = await _context.Cart.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            CartList = await _context.Cart.ToListAsync();
            foreach (Cart item in CartList)
            {
                if(User.Identity.Name.ToString() == item.UserEmail)
                {
                    Delivery.Price = item.TtlPrice;
                    Delivery.ShirtName = item.ShirtName;
                    Delivery.UserEmail = User.Identity.Name.ToString();
                    Delivery.ShirtID = item.ShirtID;
                    //if (!ModelState.IsValid)
                    //{
                        //return Page();
                    //}
                    _context.Delivery.Add(Delivery);
                    _context.Cart.Remove(item);
                    // Once a record is added, create an audit record
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        // Create an auditrecord object
                        TempData["message"] = "Purchase Successful";
                        var auditrecord = new AuditRecord();
                        auditrecord.AuditActionType = "New Delivery";
                        auditrecord.DateTimeStamp = DateTime.Now;
                        auditrecord.KeyShirtFieldID = Delivery.ID.ToString();
                        // Get current logged-in user
                        var userID = User.Identity.Name.ToString();
                        auditrecord.Username = userID;
                        _context.AuditRecords.Add(auditrecord);
                        await _context.SaveChangesAsync();
                    }

                    _context.Delivery.Add(Delivery);
                    

                }
            }
            return RedirectToPage("../Shirts/Index");

        }
    }
}
