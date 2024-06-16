using Assets.MyBakery.Sources.Infrustructure.AssetMenegment;
using Assets.MyBakery.Sources.Infrustructure.SceneMenegment;
using Assets.MyBakery.Sources.UI.LoadingCurtain;
using Cysharp.Threading.Tasks;
using System;
using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindLoadingCurtain();
            BindGameInstaller();
            BindSceneLoader();
        }

        private void BindSceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();

        private void BindGameInstaller() =>
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
