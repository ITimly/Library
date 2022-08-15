using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class LibrarianCartDetailViewModel
    {
        public IEnumerable<Order> Order { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public int Id { get; set; }
    }
}
