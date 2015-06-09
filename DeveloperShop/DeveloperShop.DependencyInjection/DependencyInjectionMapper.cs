using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperShop.DependencyInjection
{
    public static class DependencyInjectionMapper
    {
        public static void RegisterType(Type source, Type target)
        {
            DependencyInjectionContainer.RegisterType(source, target);
        }

        public static void RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            DependencyInjectionContainer.RegisterType<TFrom, TTo>();
        }
    }
}