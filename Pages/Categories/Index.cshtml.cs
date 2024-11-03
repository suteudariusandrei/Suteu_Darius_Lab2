using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suteu_Darius_Lab2.Data;
using Suteu_Darius_Lab2.Models;
using Suteu_Darius_Lab2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suteu_Darius_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Suteu_Darius_Lab2Context _context;

        public IndexModel(Suteu_Darius_Lab2Context context)
        {
            _context = context;
        }

        // Proprietate pentru a reține lista de categorii
        public IEnumerable<Category> Category { get; set; }  // Folosim `Category` la singular, conform contextului

        // ViewModel pentru a gestiona datele afișate pe pagină
        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();

        // ID-ul categoriei selectate
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            Category = await _context.Category  // Folosim `_context.Category` pentru a accesa tabelele
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = Category
                    .SingleOrDefault(c => c.ID == id.Value);

                if (selectedCategory != null)
                {
                    CategoryData.Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}
