using Suteu_Darius_Lab2.Models;
using System.Collections.Generic;

namespace Suteu_Darius_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
