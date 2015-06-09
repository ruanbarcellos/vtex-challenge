using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperShop.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        private static IUnityContainer current = new UnityContainer();

        internal static void RegisterType(Type source, Type target)
        {
            current.RegisterType(source, target);
        }

        internal static void RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            current.RegisterType<TFrom, TTo>();
        }

        public static T Resolve<T>()
        {
            return current.Resolve<T>();
        }

        internal static void Clear()
        {
            current.Dispose();
            current = new UnityContainer();
        }
    }
}