using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using SSD_Assignment___shirts4uz.Models;
using SSD_Assignment___shirts4uz.Data;
using Microsoft.AspNetCore.Authorization;


namespace SSD_Assignment___shirts4uz.Pages.Roles
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SSD_Assignment___shirts4uzContext _context;
        public CreateModel(RoleManager<ApplicationRole> roleManager, SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ApplicationRole.CreatedDate = DateTime.UtcNow;
            ApplicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            IdentityResult roleRuslt = await _roleManager.CreateAsync(ApplicationRole);
            if (roleRuslt.Succeeded)
            {
                // Create an auditrecord object
                var userID = User.Identity.Name.ToString();
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Created role: " + ApplicationRole.Name;
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyShirtFieldID = ApplicationRole.Id;
                // Get current logged-in user
               
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }

}
