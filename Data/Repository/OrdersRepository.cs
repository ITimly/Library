using Library.Data.Interfaces;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly OrderCart orderCart;
        List<Order> OrderList { get; set; }
        public OrdersRepository(AppDBContent appDBContent, OrderCart orderCart)
        {
            this.appDBContent = appDBContent;
            this.orderCart = orderCart;
        }
        public bool ValidUser(Order order)
        {
            User user = appDBContent.Users.FirstOrDefault(u => u.Email == order.Email);
            return user == null ? false : true;
        }
        public void CreateOrder(Order order)
        {
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            User user = appDBContent.Users.FirstOrDefault(u => u.Email == order.Email);
            var items = orderCart.OrderCartElements;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    BookId = el.Book.Id,
                    OrderId = order.Id,
                    User = user,
                    Status = "without status"
                };
                appDBContent.OrderDetail.Add(orderDetail);
                appDBContent.OrderCartElements.Remove(el);
            }
            appDBContent.SaveChanges();
        }
        public List<Order> GetOrder(int id)
        {
            return appDBContent.Order.Where(o => o.Id == id).ToList();
        }
        public void CompleteOrder(int id)
        {
            OrderDetail order = appDBContent.OrderDetail.FirstOrDefault(o => o.Id == id);
            if(order != null)
            {
                order.Status = "complete";
                appDBContent.OrderDetail.Update(order);
                appDBContent.SaveChanges();
            }
        }
        public void RejectOrder(int id)
        {
            OrderDetail order = appDBContent.OrderDetail.FirstOrDefault(o => o.Id == id);
            if(order != null && order.Status != "not complete")
            {
                order.Status = "not complete";
                appDBContent.OrderDetail.Update(order);
                Book book = appDBContent.Books.FirstOrDefault(b => b.Id == order.BookId);
                book.Quantity++;
                appDBContent.Books.Update(book);
                appDBContent.SaveChanges();
            }
        }
        public void OrderCheck()
        {
            IEnumerable<OrderCartElement> oldOrderCartElements = appDBContent.OrderCartElements.Include(o => o.Book).Where(o => o.OrderTime.AddMinutes(1) <= DateTime.Now);
            foreach (OrderCartElement obj in oldOrderCartElements)
            {
                Book book = appDBContent.Books.FirstOrDefault(b => b.Id == obj.Book.Id);
                book.Quantity++;
                appDBContent.Books.Update(book);
                appDBContent.OrderCartElements.Remove(obj);
            }
        }
        public IEnumerable<Order> Orders => appDBContent.Order;
        public IEnumerable<OrderDetail> OrderDetails => appDBContent.OrderDetail.Include(u => u.User);
    }
}
