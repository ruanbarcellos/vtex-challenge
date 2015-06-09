using DeveloperShop.DependencyInjection;
using DeveloperShop.Domain.Provider;
using DeveloperShop.Domain.Repository;
using DeveloperShop.Infrastructure.Provider;
using DeveloperShop.Infrastructure.Repository;

namespace DeveloperShop.API
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            DependencyInjectionMapper.RegisterType<IGitHubProvider, GitHubProvider>();
            DependencyInjectionMapper.RegisterType<IOrderRepository, OrderRepository>();
        }
    }
}