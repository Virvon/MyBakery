﻿using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Infrustructure.AssetManagement;
using Virvon.MyBakery.Services;
using Virvon.MyBakery.Services.Input;
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

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        }
    }
}