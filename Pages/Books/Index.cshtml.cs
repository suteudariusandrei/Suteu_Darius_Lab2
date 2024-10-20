using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;  // For SelectList
using Microsoft.EntityFrameworkCore;
using Suteu_Darius_Lab2.Data;
using Suteu_Darius_Lab2.Models;

namespace Suteu_Darius_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Suteu_Darius_Lab2.Data.Suteu_Darius_Lab2Context _context;

        public IndexModel(Suteu_Darius_Lab2.Data.Suteu_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; } // For filtering by author

        public async Task OnGetAsync()
        {
            // Populate the list of authors for the dropdown with concatenated FirstName and LastName
            ViewData["AuthorID"] = new SelectList(
                await _context.Authors.Select(a => new
                {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName // Concatenating FirstName and LastName
                }).ToListAsync(), "ID", "FullName");

            // Fetch books and include authors and publishers
            var booksQuery = _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsQueryable();

            // If an author is selected, filter books by that author
            if (AuthorID.HasValue)
            {
                booksQuery = booksQuery.Where(b => b.AuthorID == AuthorID.Value);
            }

            // Execute the query and get the list of books
            Book = await booksQuery.ToListAsync();
        }
    }
}
