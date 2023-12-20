using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Services;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField] private LoadingPanel _loadingPanelPrefab;

        public override void InstallBindings()
        {
            BindSceneLoader();
            BindLoadingPanel();
            BindFactories();
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

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        }
    }
}