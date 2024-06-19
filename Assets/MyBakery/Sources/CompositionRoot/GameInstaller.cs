using Cysharp.Threading.Tasks;
using System;
using Virvon.MyBakery.Gameplay;
using Virvon.MyBakery.Infrustructure;
using Virvon.MyBakery.Infrustructure.AssetManagement;
using Virvon.MyBakery.Infrustructure.States;
using Virvon.MyBakery.Services.Input;
using Virvon.MyBakery.UI;
using Zenject;

namespace Virvon.MyBakery.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindLoadingCurtain();
            BindAssetProvider();
            BindSceneLoader();
            BindInputService();
            BindGameplayFactory();
        }

        private void BindGameplayFactory()
        {
            Container
                .Bind<IGameplayFactory>()
                .FromSubContainerResolve()
                .ByInstaller<GameplayFactoryInstaller>()
                .AsSingle();
        }

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle();

        private void BindSceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();

        private void BindAssetProvider() =>
            Container.BindInterfacesTo<AssetProvider>().AsSingle();

        private void BindLoadingCurtain()
        {
            Container.BindFactory<string, UniTask<LoadingCurtain>, LoadingCurtain.Factory>().FromFactory<PrefabFactoryAsync<LoadingCurtain>>();
            Container.BindInterfacesAndSelfTo<LoadingCurtainProxy>().AsSingle();
        }

        private void BindGameStateMachine() => 
            GameStateMachineInstaller.Install(Container);
    }
}
