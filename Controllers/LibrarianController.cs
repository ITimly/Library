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
    public class LibrarianController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly IAllUsers allUsers;
        private readonly IAllBooks allBooks;
        public LibrarianController(IAllOrders allOrders, IAllUsers allUsers, IAllBooks allBooks)
        {
            this.allOrders = allOrders;
            this.allUsers = allUsers;
            this.allBooks = allBooks;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderDetail> OrderDetail = allOrders.OrderDetails;
            LibrarianViewModel obj = new LibrarianViewModel
            {
                OrderDetail = OrderDetail
            };
            return View(obj);
        }
        public IActionResult OrderDetailCart(int id)
        {
            OrderDetail OrderDetail = allOrders.OrderDetails.FirstOrDefault(o => o.Id == id);
            List<Order> orderList = allOrders.GetOrder(OrderDetail.OrderId);
            List<User> userList = allUsers.GetUsers(OrderDetail.User.Id);
            List<Book> bookList = allBooks.GetBook(OrderDetail.BookId);
            LibrarianCartDetailViewModel obj = new LibrarianCartDetailViewModel
            {
                Order = orderList,
                User = userList,
                Books = bookList,
                Id = id
            };
            return View(obj);
        }
        public IActionResult BookControl(int id)
        {
            BookControlViewModel obj = new BookControlViewModel
            {
                Books = allBooks.Books
            };
            return View(obj);
        }
        public RedirectToActionResult CompleteOrder(int id)
        {
            allOrders.CompleteOrder(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RejectOrder(int id)
        {
            allOrders.RejectOrder(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult BookAdd(int id)
        {
            allBooks.BookAdd(id);
            return RedirectToAction("BookControl");
        }
        public RedirectToActionResult BookTake(int id)
        {
            allBooks.BookTake(id);
            return RedirectToAction("BookControl");
        }
    }
}
