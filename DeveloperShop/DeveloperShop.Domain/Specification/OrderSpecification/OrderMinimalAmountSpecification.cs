using DeveloperShop.Domain.Entity;
using System;

namespace DeveloperShop.Domain.Specification.OrderSpecification
{
    public class OrderMinimalAmountSpecification : ISpecification<Order>
    {
        public Boolean IsSatisfiedBy(Order entity)
        {
            return entity.Amount > 0;
        }
    }
}