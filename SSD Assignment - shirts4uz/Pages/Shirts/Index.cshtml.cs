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
    }
}
