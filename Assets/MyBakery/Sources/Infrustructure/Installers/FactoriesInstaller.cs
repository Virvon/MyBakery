using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.Infrustrucure
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