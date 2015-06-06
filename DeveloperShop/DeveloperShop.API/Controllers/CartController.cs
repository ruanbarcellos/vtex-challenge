using DeveloperShop.Domain.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace DeveloperShop.API.Controllers
{
    public class CartController : ApiController
    {
        // GET: api/Cart/5
        [HttpGet]
        public Cart Get(int id)
        {
            return null;
        }

        // POST: api/Cart
        [HttpPost]
        public void Post([FromBody] Cart cart)
        {
        }

        // DELETE: api/Cart/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}