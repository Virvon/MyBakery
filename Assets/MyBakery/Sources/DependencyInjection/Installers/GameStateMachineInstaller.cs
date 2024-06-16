using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStates();
            BindStateMachine();
        }

        private void BindStates()
        {
            //Container.Bind<BootstrapState>().AsSingle().NonLazy();
            //Container.Bind<LoadGameLevelState>().AsSingle().NonLazy();
            //Container.Bind<GameLoopState>().AsSingle().NonLazy();
        }

        private void BindStateMachine()
        {
            //Container
            //    .BindInterfacesAndSelfTo<GameStateMachine>()
            //    .AsSingle()
            //    .NonLazy();
        }
    }
}