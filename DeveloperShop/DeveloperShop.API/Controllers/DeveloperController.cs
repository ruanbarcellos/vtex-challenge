using DeveloperShop.DependencyInjection;
using DeveloperShop.Domain.Entity;
using DeveloperShop.Domain.Provider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeveloperShop.API.Controllers
{
    [RoutePrefix("api/Developer")]
    public class DeveloperController : ApiController
    {
        // GET: api/Developer/GitHub
        [Route("GetFromOrganization/{id}"), HttpGet]
        public async Task<IEnumerable<Developer>> GetFromOrganization(String id)
        {
            return await DependencyInjectionContainer.Resolve<IGitHubProvider>().GetDevelopers(id);
        }

        // GET: api/Developer/5
        [HttpGet]
        public async Task<Developer> Get(String id)
        {
            return await DependencyInjectionContainer.Resolve<IGitHubProvider>().GetDeveloper(id);
        }
    }
}