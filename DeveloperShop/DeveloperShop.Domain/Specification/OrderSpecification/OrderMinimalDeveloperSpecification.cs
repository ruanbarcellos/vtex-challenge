using DeveloperShop.Domain.Entity;
using System;
using System.Linq;

namespace DeveloperShop.Domain.Specification.OrderSpecification
{
    public class OrderMinimalDeveloperSpecification : ISpecification<Order>
    {
        public Boolean IsSatisfiedBy(Order entity)
        {
            return entity.Developers != null && entity.Developers.Any();
        }
    }
}