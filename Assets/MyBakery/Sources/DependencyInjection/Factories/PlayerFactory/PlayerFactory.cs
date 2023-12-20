using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer _container;

        private Object _playerPrefab;

        public PlayerFactory(DiContainer container)
        {
            _container = container;
        }

        public void Load()
        {
            _playerPrefab = Resources.Load("Player");
        }

        public void Create()
        {
            Player player = _container.InstantiatePrefabForComponent<Player>(_playerPrefab);

            _container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}
