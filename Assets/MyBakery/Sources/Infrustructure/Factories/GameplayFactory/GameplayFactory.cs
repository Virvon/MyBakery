using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Gameplay;
using Virvon.MyBakery.Gameplay.Characters;
using Zenject;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private readonly DiContainer _container;
        private readonly HudFactory _gameObjectFactory;
        private readonly PlayerCharacter.Factory _playerCharacterFactory;
        private readonly PlayerCharacterCamera.Factory _playerCharacterCameraFactory;

        public GameplayFactory(DiContainer container, HudFactory gameObjectFactory, PlayerCharacter.Factory playerCharacterFactory, PlayerCharacterCamera.Factory playerCharacterCameraFactory)
        {
            _container = container;
            _gameObjectFactory = gameObjectFactory;
            _playerCharacterFactory = playerCharacterFactory;
            _playerCharacterCameraFactory = playerCharacterCameraFactory;
        }

        public UniTask CreateHud() => 
            _gameObjectFactory.Create(GameplayFactoryAssets.Hud);

        public async UniTask CreatePlayerCharacter(Vector3 position)
        {
            PlayerCharacter playerCharacter = await _playerCharacterFactory.Create(GameplayFactoryAssets.PlayerCharacter);
            playerCharacter.transform.position = position;
            _container.Bind<PlayerCharacter>().FromInstance(playerCharacter).AsSingle();

            PlayerCharacterMovement x = playerCharacter.GetComponent<PlayerCharacterMovement>();
            _container.Bind<PlayerCharacterMovement>().FromInstance(x).AsSingle();
        }

        public UniTask CreatePlayerCharacterCamera() =>
            _playerCharacterCameraFactory.Create(GameplayFactoryAssets.PlayerCharacterCamera);
    }
}
