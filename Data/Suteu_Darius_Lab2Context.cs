using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Suteu_Darius_Lab2.Models;

namespace Suteu_Darius_Lab2.Data
{
    public class Suteu_Darius_Lab2Context : DbContext
    {
        public Suteu_Darius_Lab2Context (DbContextOptions<Suteu_Darius_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Suteu_Darius_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Suteu_Darius_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Suteu_Darius_Lab2.Models.Author> Authors { get; set; } = default!;
        public DbSet<Suteu_Darius_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Suteu_Darius_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Suteu_Darius_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
       
    }
}
