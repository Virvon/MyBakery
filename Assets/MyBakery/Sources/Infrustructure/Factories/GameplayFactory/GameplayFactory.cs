using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Gameplay;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private readonly HudFactory _gameObjectFactory;
        private readonly PlayerCharacter.Factory _playerCharacterFactory;

        public GameplayFactory(HudFactory gameObjectFactory, PlayerCharacter.Factory playerCharacterFactory)
        {
            _gameObjectFactory = gameObjectFactory;
            _playerCharacterFactory = playerCharacterFactory;
        }

        public UniTask CreateHud() => 
            _gameObjectFactory.Create(GameplayFactoryAssets.Hud);

        public async UniTask CreatePlayerCharacter(Vector3 position)
        {
            PlayerCharacter playerCharacter = await _playerCharacterFactory.Create(GameplayFactoryAssets.PlayerCharacter);
            playerCharacter.transform.position = position;
            //GameObject playerCharacter = await _gameObjectFactory.Create(GameplayFactoryAssets.PlayerCharacter);
            ////playerCharacter.transform.position = position;
            //playerCharacter.GetComponent<Transform>().position = position;
        }
    }
}
