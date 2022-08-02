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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SSD_Assignment___shirts4uz.Pages.Audit
{
    [Authorize(Roles = "Auditor")]
    public class IndexModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;
        public IList<AuditRecord> AuditList { get; set; }
        [BindProperty(SupportsGet = true)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        public string SearchString { get; set; }
        public SelectList ActionType { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AuditActionType { get; set; }
        [BindProperty]
        public AuditRecord AuditRecords { get; set; }
        public IndexModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        public IList<AuditRecord> AuditRecord { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> actionQuery = from m in _context.AuditRecords
                                               orderby m.AuditActionType
                                               select m.AuditActionType;
            var audits = from m in _context.AuditRecords
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                audits = audits.Where(s => s.AuditActionType.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(AuditActionType))
            {
                audits = audits.Where(x => x.AuditActionType == AuditActionType);
            }
            ActionType = new SelectList(await actionQuery.Distinct().ToListAsync());
            AuditList = await audits.ToListAsync();
        }
    }
}
