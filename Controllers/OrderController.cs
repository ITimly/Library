using Library.Data.Interfaces;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class OrderController : Controller
    {
        public IAllOrders allOrders; 
        public OrderCart orderCart;
        public OrderController(IAllOrders allOrders, OrderCart orderCart)
        {
            this.allOrders = allOrders;
            this.orderCart = orderCart;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Order order)
        {
            orderCart.OrderCartElements = orderCart.GetOrderItems();
            if(orderCart.OrderCartElements.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары в корзине!");
            }
            if (ModelState.IsValid && allOrders.ValidUser(order))
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            else
                ModelState.AddModelError("ValidUser", "Ошибка в заполнении формы!");
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
