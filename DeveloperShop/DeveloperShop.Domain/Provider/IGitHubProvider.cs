using DeveloperShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperShop.Domain.Provider
{
    public interface IGitHubProvider
    {
        Task<IEnumerable<Developer>> GetDevelopers();
        Task<Developer> GetDeveloper(String developerLogin);
    }
}