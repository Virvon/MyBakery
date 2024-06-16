using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class InitInstaller : MonoInstaller, IInitializable
    {
        private const string GameScene = "Game";

        public override void InstallBindings()
        {
            BindSelfInterface();
        }

        public void Initialize()
        {
            EnterGameLoopState();
        }

        private void BindSelfInterface()
        {
            Container
                .BindInterfacesTo<InitInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void EnterGameLoopState()
        {
            //GameStateMachine stateMachine = Container.Resolve<Game>().StateMachine;

            //stateMachine.Enter<LoadGameLevelState, string>(GameScene, stateMachine.Enter<GameLoopState>);
        }
    }

}