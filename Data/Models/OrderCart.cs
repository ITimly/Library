using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class OrderCart
    {
        private readonly AppDBContent appDBContent;
        public OrderCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string OrderCartId { get; set; }
        public List<OrderCartElement> OrderCartElements { get; set; }
        public static OrderCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string orderCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", orderCartId);
            return new OrderCart(context) { OrderCartId = orderCartId };
        }
        public void AddToCart(Book book)
        {
            appDBContent.OrderCartElements.Add(new OrderCartElement
            {
                Book = book,
                OrderCartId = OrderCartId,
                OrderTime = DateTime.Now
            });
            book.Quantity--;
            appDBContent.Books.Update(book);
            appDBContent.SaveChanges();
        }
        public void RemoveFromCart(int id)
        {
            IEnumerable<OrderCartElement> orderCartElement = appDBContent.OrderCartElements.Include(i => i.Book);
            OrderCartElement order = orderCartElement.FirstOrDefault(i => i.Id == id);
            Book book = appDBContent.Books.FirstOrDefault(o => o.Id == order.Book.Id);
            book.Quantity++;
            appDBContent.Books.Update(book);
            appDBContent.OrderCartElements.Remove(appDBContent.OrderCartElements.FirstOrDefault(i => i.Id == id));
            appDBContent.SaveChanges();
        }
        public List<OrderCartElement> GetOrderItems()
        {
            return appDBContent.OrderCartElements.Where(c => c.OrderCartId == OrderCartId).Include(s => s.Book).ToList();
        }
    }
}
