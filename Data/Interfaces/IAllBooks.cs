using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
    public interface IAllBooks
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> GetBooks { get; }
        Book GetObjBook(int id);
        List<Book> GetBook(int id);
        void BookAdd(int id);
        void BookTake(int id);
    }
}
