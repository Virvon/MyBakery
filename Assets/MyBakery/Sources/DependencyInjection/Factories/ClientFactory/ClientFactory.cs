using UnityEngine;
using Zenject;
using Virvon.MyBakery.Client;

namespace Virvon.MyBakery.DependencyInjection.Factories
{
    public class ClientFactory : IClientFactory
    {
        private readonly DiContainer _diContainer;

        private Object _clientPrefab;

        public ClientFactory(DiContainer container)
        {
            _diContainer = container;
            Debug.Log(_diContainer);
        }

        public void Load()
        {
            Debug.Log("Load client state machine");
            _clientPrefab = Resources.Load("Client");

            _diContainer
                .Bind<ClientStateMachine>()
                .FromNew()
                .AsTransient();

            Debug.Log("Have client state machine " + (_diContainer.Resolve<ClientStateMachine>() != null));
        }

        public void Create()
        {
            GameObject prefab = _diContainer.InstantiatePrefab(_clientPrefab);
        }
    }
}
