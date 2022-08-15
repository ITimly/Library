using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> FavBooks { get; set; }
    }
}
