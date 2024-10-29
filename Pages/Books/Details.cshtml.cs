using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Siciu_Alina_Lab2.Data;
using Siciu_Alina_Lab2.Models;

namespace Siciu_Alina_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context _context;

        public DetailsModel(Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;
        public List<Category> Categories { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(m => m.ID == id);


            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            Categories = Book.BookCategories.Select(bc => bc.Category).ToList();

            return Page();

        }
    }
}
