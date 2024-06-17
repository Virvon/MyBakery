using Cysharp.Threading.Tasks;
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
            BindGameInstaller();
            BindSceneLoader();
            BindInputService();
        }

        private void BindInputService() => 
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle();

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
