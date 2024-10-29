using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Siciu_Alina_Lab2.Data;
using Siciu_Alina_Lab2.Models;
using Siciu_Alina_Lab2.Models.ViewModels;

namespace Siciu_Alina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context _context;

        public IndexModel(Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoriesIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            Category = await _context.Category.ToListAsync();
            CategoryData = new CategoriesIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(c => c.Book).ThenInclude(d=>d.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc=>bc.Book);
            }
        }
    }
}
