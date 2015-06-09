using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperShop.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private static IList<Order> orders;
        private static IList<Order> Orders
        {
            get
            {
                return orders ?? (orders = new List<Order>());
            }
        }

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public void Remove(Order order)
        {
            Orders.Remove(order);
        }

        public Order Get(int orderId)
        {
            return Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetAll()
        {
            return Orders;
        }
    }
}