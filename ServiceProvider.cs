using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public static class ServiceProvider
    {
        static GameServiceContainer services;

        public static void Initialize(GameServiceContainer gameServices)
        {
            services = gameServices;
        }

        public static void AddService<T>(T service)
        {
            services.AddService(typeof(T), service);
        }

        public static T GetService<T>()
        {
            return (T)services.GetService(typeof(T));
        }
    }
}
