﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Suteu_Darius_Lab2.Data;
using Suteu_Darius_Lab2.Models;

namespace Suteu_Darius_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Suteu_Darius_Lab2.Data.Suteu_Darius_Lab2Context _context;

        public CreateModel(Suteu_Darius_Lab2.Data.Suteu_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Authors.Select(a => new
            {
                ID = a.ID,
                FullName = a.FirstName + " " + a.LastName
            }).ToList();
            ViewData["AuthorID"] = new SelectList(_context.Authors.Select(a => new
            {
                a.ID,
                FullName = a.FirstName + " " + a.LastName
            }), "ID", "FullName");

            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

