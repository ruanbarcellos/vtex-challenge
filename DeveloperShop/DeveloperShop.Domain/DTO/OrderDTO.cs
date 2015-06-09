using DeveloperShop.Domain.Entity;
using System;
using System.Collections.Generic;

namespace DeveloperShop.Domain.DTO
{
    public class OrderDTO
    {
        public Int32 OrderId { get; set; }
        public Double Amount { get; set; }
        public IEnumerable<Developer> Developers { get; set; }
    }
}