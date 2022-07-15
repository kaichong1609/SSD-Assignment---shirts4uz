using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;

namespace SSD_Assignment___shirts4uz.Pages.Shirts
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public CreateModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IFormFile Photo { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public Shirt Shirt { get; set; }    

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shirt.Add(Shirt);
            //await _context.SaveChangesAsync();
            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add Shirt Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyShirtFieldID = Shirt.ID;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }


            _context.Shirt.Add(Shirt);

            return RedirectToPage("./Index");
        }
    }
}
