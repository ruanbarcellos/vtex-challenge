using DeveloperShop.Domain.Entity;
using System;
using System.Collections.Generic;

namespace DeveloperShop.Domain.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Remove(Order order);
        Order Get(Int32 orderId);
        IEnumerable<Order> GetAll();
    }
}