using Library.Data.Interfaces;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class BookRepository : IAllBooks
    {
        private readonly AppDBContent appDBContent;     
        public BookRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Book> Books => appDBContent.Books.Include(c => c.Genre).OrderByDescending(i => i.Id);

        public IEnumerable<Book> GetBooks => appDBContent.Books.Where(g => g.IsFavorite).Include(b => b.Genre).OrderByDescending(i => i.Id);

        public Book GetObjBook(int id) => appDBContent.Books.FirstOrDefault(b => b.Id == id);
        public List<Book> GetBook(int id)
        {
            return appDBContent.Books.Where(b => b.Id == id).ToList();
        }
        public void BookAdd(int id)
        {
            Book book = appDBContent.Books.FirstOrDefault(b => b.Id == id);
            book.Quantity++;
            appDBContent.Books.Update(book);
            appDBContent.SaveChanges();
        }
        public void BookTake(int id)
        {
            Book book = appDBContent.Books.FirstOrDefault(b => b.Id == id);
            book.Quantity--;
            appDBContent.Books.Update(book);
            appDBContent.SaveChanges();
        }
    }
}
