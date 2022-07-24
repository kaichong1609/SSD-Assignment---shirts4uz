using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSD_Assignment___shirts4uz.Models;
using SSD_Assignment___shirts4uz.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace SSD_Assignment___shirts4uz.Pages.Roles
{
    //[Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uzContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public DeleteModel(RoleManager<ApplicationRole> roleManager, SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
            _roleManager = roleManager;
        }
        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationRole = await _roleManager.FindByIdAsync(id);
            if (ApplicationRole == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationRole = await _roleManager.FindByIdAsync(id);
            IdentityResult roleRuslt = await _roleManager.DeleteAsync(ApplicationRole);
            if (roleRuslt.Succeeded)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Delete existing role";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyShirtFieldID = ApplicationRole.Id;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
