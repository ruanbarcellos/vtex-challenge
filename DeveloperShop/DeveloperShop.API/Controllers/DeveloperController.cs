using DeveloperShop.Domain.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace DeveloperShop.API.Controllers
{
    public class DeveloperController : ApiController
    {
        // GET: api/Developer
        [HttpGet]
        public IEnumerable<Developer> Get()
        {
            return null;
        }

        // GET: api/Developer/5
        [HttpGet]
        public string Get(int id)
        {
            return null;
        }
    }
}