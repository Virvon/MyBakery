using Virvon.MyBakery.DependencyInjection.Factories;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
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