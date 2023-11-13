using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virvon.MyBackery.Services
{
    public class AllServices
    {
        private static AllServices _instance;

        public static AllServices Instance => _instance ??= new();

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementatioin<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementatioin<TService>.ServiceInstance;

        private static class Implementatioin<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
