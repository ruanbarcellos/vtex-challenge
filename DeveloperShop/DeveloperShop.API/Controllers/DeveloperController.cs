using DeveloperShop.DependencyInjection;
using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Provider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeveloperShop.API.Controllers
{
    public class DeveloperController : ApiController
    {
        // GET: api/Developer
        [HttpGet]
        public async Task<IEnumerable<Developer>> Get()
        {
            return await DependencyInjectionContainer.Resolve<IGitHubProvider>().GetDevelopers();
        }

        // GET: api/Developer/5
        [HttpGet]
        public async Task<Developer> Get(String id)
        {
            return await DependencyInjectionContainer.Resolve<IGitHubProvider>().GetDeveloper(id);
        }
    }
}