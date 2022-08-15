using Library.Data.Interfaces;
using Library.Data.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IAllGenres _allGenres;
        public BooksController(IAllBooks allBooks, IAllGenres allGenres)
        {
            _allBooks = allBooks;
            _allGenres = allGenres;
        }
        [Route("Books/List")]
        [Route("Books/List/{genre}")]
        public ViewResult List(string genre)
        {
            IEnumerable<Genre> genres = _allGenres.AllGenres;
            string _genre = genre;
            IEnumerable<Book> books = null;
            string currGenre = "";
            if (string.IsNullOrEmpty(genre))
            {
                books = _allBooks.Books;
            }
            else
            {
                books = _allBooks.Books.Where(i => i.Genre.Name.Equals(genre));
                currGenre = _genre;
            }
            var bookObj = new BooksListViewModel
            {
                getAllBooks = books,
                currGenre = currGenre,
                getAllGenres = genres
            };
            return View(bookObj);
        }
    }
}
