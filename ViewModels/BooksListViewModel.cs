using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> getAllBooks { get; set; }
        public IEnumerable<Genre> getAllGenres { get; set; }
        public string currGenre { get; set; }
    }
}
