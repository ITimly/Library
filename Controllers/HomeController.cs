using Library.Data.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBooks _bookRep;
        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;
        }
        public ViewResult Index()
        {
            HomeViewModel homeBooks = new HomeViewModel
            {
                FavBooks = _bookRep.GetBooks
            };
            return View(homeBooks);
        }
    }
}
