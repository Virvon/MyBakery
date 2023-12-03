using Virvon.Infrustructure;
using Zenject;

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
