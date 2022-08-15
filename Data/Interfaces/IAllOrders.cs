using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
        bool ValidUser(Order order);
        List<Order> GetOrder(int id);
        void CompleteOrder(int id);
        void RejectOrder(int id);
        void OrderCheck();
        IEnumerable<Order> Orders { get; }
        IEnumerable<OrderDetail> OrderDetails { get; }
    }
}
