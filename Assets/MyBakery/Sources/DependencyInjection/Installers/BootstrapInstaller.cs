using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Infrustructure;
using Virvon.MyBakery.Services;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _loadingPanelPrefab;

        public override void InstallBindings()
        {
            BindSceneLoader();
            BindFactories();
            BindGame();
            BindLoadingPanel();
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<JoystickInput>()
                .AsSingle()
                .NonLazy();
        }

        private void BindLoadingPanel()
        {
            LoadingPanel loadingPanel = Container
                        .InstantiatePrefabForComponent<LoadingPanel>(_loadingPanelPrefab);

            Container
                .Bind<LoadingPanel>()
                .FromInstance(loadingPanel)
                .AsSingle();
        }

        private void BindFactories()
        {
            Container
                .Bind<IClientFactory>()
                .To<ClientFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGame()
        {
            Container
                .Bind<Game>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}