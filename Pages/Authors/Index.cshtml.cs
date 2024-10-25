using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Siciu_Alina_Lab2.Data;
using Siciu_Alina_Lab2.Models;

namespace Siciu_Alina_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context _context;

        public IndexModel(Siciu_Alina_Lab2.Data.Siciu_Alina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
