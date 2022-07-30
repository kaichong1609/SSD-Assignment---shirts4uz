using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SSD_Assignment___shirts4uz.Data;
using SSD_Assignment___shirts4uz.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSD_Assignment___shirts4uz.Pages.Deliveries
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public IndexModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        public IList<Delivery> Deliveries { get; set; }
        public SelectList AllDeliveries { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentUser { get; set; }

        public async Task OnGetAsync()
        {
            if(!User.IsInRole("Product Manager"))
            {
                CurrentUser = User.Identity.Name.ToString();
                IQueryable<string> userQuery = from m in _context.Delivery
                                               orderby m.UserEmail
                                               select m.UserEmail;
                var delivery = from m in _context.Delivery
                               select m;
                if (!string.IsNullOrEmpty(CurrentUser))
                {
                    delivery = delivery.Where(x => x.UserEmail == CurrentUser);
                }
                AllDeliveries = new SelectList(await userQuery.Distinct().ToListAsync());
                Deliveries = await delivery.ToListAsync();
            }
            else
            {
                Deliveries = await _context.Delivery.ToListAsync();
            }
        }
    }
}
