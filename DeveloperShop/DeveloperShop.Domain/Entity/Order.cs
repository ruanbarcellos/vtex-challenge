using System;
using System.Collections.Generic;

namespace DeveloperShop.Domain.Entity
{
    public class Order
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Developer> Developers { get; set; }
        public Double Amount { get; set; }
    }
}