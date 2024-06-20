using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Gameplay.Characters;
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

            Container
                .BindFactory<string, UniTask<PlayerCharacter>, PlayerCharacter.Factory>()
                .FromFactory<PrefabFactoryAsync<PlayerCharacter>>();

            Container
                .BindFactory<string, UniTask<PlayerCharacterCamera>, PlayerCharacterCamera.Factory>()
                .FromFactory<PrefabFactoryAsync<PlayerCharacterCamera>>();
        }
    }
}
