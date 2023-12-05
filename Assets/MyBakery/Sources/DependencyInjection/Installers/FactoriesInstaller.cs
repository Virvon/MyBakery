using Zenject;

namespace Virvon.MyBakery.DependencyInjection
{
    internal class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IClientFactory>()
                .To<ClientFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}