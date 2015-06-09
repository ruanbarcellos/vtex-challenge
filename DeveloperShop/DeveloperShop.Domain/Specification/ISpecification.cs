using System;

namespace DeveloperShop.Domain.Specification
{
    public interface ISpecification<T>
    {
        Boolean IsSatisfiedBy(T entity);
    }
}