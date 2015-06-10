using DeveloperShop.DependencyInjection;
using DeveloperShop.Domain.DTO;
using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Repository;
using DeveloperShop.Domain.Service;
using System;
using System.Web.Http;

namespace DeveloperShop.API.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order/5
        [HttpGet]
        public Order Get(Int32 id)
        {
            return DependencyInjectionContainer.Resolve<IOrderRepository>().Get(id);
        }

        // POST: api/Order
        [HttpPost]
        public IHttpActionResult Post([FromBody] OrderDTO order)
        {
            new OrderService().SaveOrder(order);
            return Ok();
        }

        // DELETE: api/Order/5
        [HttpDelete]
        public void Delete(int id)
        {
            var repository = DependencyInjectionContainer.Resolve<IOrderRepository>();
            var order = repository.Get(id);

            repository.Remove(order);
        }
    }
}