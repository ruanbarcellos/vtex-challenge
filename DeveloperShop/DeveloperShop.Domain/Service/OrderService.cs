using DeveloperShop.Domain.DTO;
using DeveloperShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperShop.Domain.Service
{
    public class OrderService
    {
        public void SaveOrder(OrderDTO order)
        {

        }

        private Order GetFromDTO(OrderDTO orderDTO)
        {
            return new Order
            {
                Developers = orderDTO.Developers
            };
        }
    }
}