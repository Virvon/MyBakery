using Virvon.MyBakery.Gameplay.Characters;
using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameplayBootstrapper();
            BindGameplayFactory();
            BindPlayerCharacterStateMachine();
        }

        private void BindPlayerCharacterStateMachine() =>
            PlayerCharacterStateMachineInstaller.Install(Container);

        private void BindGameplayFactory() =>
            GameplayFactoryInstaller.Install(Container);

        private void BindGameplayBootstrapper() =>
            Container.BindInterfacesAndSelfTo<GameplayBootstrapper>().AsSingle().NonLazy();
    }

    public class PlayerCharacterStateMachineInstaller : Installer<PlayerCharacterStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<PlayerCharacterStateMachine>().AsSingle();
        }
    }

    public class StatesFactory
    {
        private IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public TState Create<TState>() where TState : IState =>
            _instantiator.Instantiate<TState>();
    }
}