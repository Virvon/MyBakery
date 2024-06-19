using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Infrustructure;
using Virvon.MyBakery.Infrustructure.AssetManagement;
using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class GameplayFactoryInstaller : Installer<GameplayFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameplayFactory>().To<GameplayFactory>().AsSingle();

            Container
                .BindFactory<string, UniTask<GameObject>, HudFactory>()
                .FromFactory<PrefabFactoryAsync<GameObject>>();
        }
    }
}
