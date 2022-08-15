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
    public class OrderCartController : Controller
    {
        private readonly IAllBooks _bookRep;
        private readonly IAllOrders _orderRep;
        private readonly OrderCart _orderCart;
        public OrderCartController(IAllBooks bookRep, IAllOrders orderRep, OrderCart orderCart)
        {
            _bookRep = bookRep;
            _orderRep = orderRep;
            _orderCart = orderCart;
        }
        public ViewResult Index()
        {
            var items = _orderCart.GetOrderItems();
            _orderCart.OrderCartElements = items;
            var obj = new OrderCartViewModel
            {
                OrderCart = _orderCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            _orderRep.OrderCheck();
            Book item = _bookRep.Books.FirstOrDefault(c => c.Id == id);
            if(item != null)
                _orderCart.AddToCart(item);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int id)
        {
            _orderRep.OrderCheck();
            _orderCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
