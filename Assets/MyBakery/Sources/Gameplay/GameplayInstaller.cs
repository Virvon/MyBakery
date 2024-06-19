using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayBootstrapper>().AsSingle().NonLazy();
            GameplayFactoryInstaller.Install(Container);
        }
    }
}