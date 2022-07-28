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

namespace SSD_Assignment___shirts4uz.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext _context;

        public IndexModel(SSD_Assignment___shirts4uz.Data.SSD_Assignment___shirts4uzContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; }
        public SelectList AllOrders { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentUser { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUser = User.Identity.Name.ToString();
            IQueryable<string> userQuery = from m in _context.Order
                                               orderby m.UserEmail
                                               select m.UserEmail;
            var orders = from m in _context.Order
                         select m;
            if (!string.IsNullOrEmpty(CurrentUser))
            {
                orders = orders.Where(x => x.UserEmail == CurrentUser);
            }
            AllOrders = new SelectList(await userQuery.Distinct().ToListAsync());
            Order = await orders.ToListAsync();
        }
    }
}
