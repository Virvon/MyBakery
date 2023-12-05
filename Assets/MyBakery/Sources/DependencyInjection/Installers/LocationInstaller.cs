using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection
{
    internal class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _testQueue;

        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            Player player = Container
                       .InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint);

            Container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}