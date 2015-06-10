using DeveloperShop.DependencyInjection;
using DeveloperShop.Domain.DTO;
using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Repository;
using DeveloperShop.Domain.Specification.OrderSpecification;
using System;

namespace DeveloperShop.Domain.Service
{
    public class OrderService
    {
        public void SaveOrder(OrderDTO orderDTO)
        {
            var order = GetFromDTO(orderDTO);
            if (new OrderMinimalAmountSpecification().IsSatisfiedBy(order) && new OrderMinimalDeveloperSpecification().IsSatisfiedBy(order))
            {
                DependencyInjectionContainer.Resolve<IOrderRepository>().Add(order);
            }
        }

        private Order GetFromDTO(OrderDTO orderDTO)
        {
            return new Order
            {
                Developers = orderDTO.Developers,
                Date = DateTime.Today,
                Amount = orderDTO.Amount,
                Id = new Random().Next()
            };
        }
    }
}