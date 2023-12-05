using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection
{
    internal class ClientFactory : IClientFactory
    {
        private readonly DiContainer _diContainer;

        private Object _clientPrefab;

        public ClientFactory(DiContainer container)
        {
            _diContainer = container;
        }

        public void Load()
        {
            _clientPrefab = Resources.Load("Client");
        }

        public void Create()
        {
            var prefab =  _diContainer.InstantiatePrefab(_clientPrefab);
        }
    }
}
