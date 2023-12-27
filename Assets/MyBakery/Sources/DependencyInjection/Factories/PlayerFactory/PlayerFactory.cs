using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer _container;

        private GameObject _playerPrefab;

        public PlayerFactory(DiContainer container) => 
            _container = container;

        public void Load()
        {
            _playerPrefab = Resources.Load<GameObject>("Player");
        }

        public void Create()
        {
            Player player = Object.Instantiate(_playerPrefab).GetComponent<Player>();

            _container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();

            _container.InjectGameObject(_playerPrefab);
        }
    }
}
