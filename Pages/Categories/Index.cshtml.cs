using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Darius_Lab2.Data;
using Suteu_Darius_Lab2.Models;

namespace Suteu_Darius_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Suteu_Darius_Lab2Context _context;

        public IndexModel(Suteu_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = new List<Category>();

        public async Task OnGetAsync()
        {
            Categories = await _context.Category.ToListAsync();
        }
    }
}
