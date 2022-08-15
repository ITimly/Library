using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class BookControlViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
