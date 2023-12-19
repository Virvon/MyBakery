using UnityEngine;
using Virvon.MyBakery.Equipment;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _testQueue;

        public override void InstallBindings()
        {
            BindPlayer();
            BindTestQueue();
        }

        private void BindTestQueue()
        {
            Debug.Log("bind queue");
            TestQueue queue = Container.InstantiatePrefabForComponent<TestQueue>(_testQueue);

            Container
                .Bind<TestQueue>()
                .FromInstance(queue)
                .AsSingle();

            Debug.Log(Container);

            Debug.Log("Have queue " + (Container.Resolve<TestQueue>() != null));
        }

        private void BindPlayer()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint);

            Container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}