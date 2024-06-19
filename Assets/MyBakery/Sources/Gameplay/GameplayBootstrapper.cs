using UnityEngine;
using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class GameplayBootstrapper : IInitializable
    {
        private const string PlayerCharacterStartPoint = "PlayerCharacterInitializePoint";

        private readonly IGameplayFactory _gameplayFactory;

        public GameplayBootstrapper(IGameplayFactory gameplayFactory)
        {
            _gameplayFactory = gameplayFactory;
        }

        public async void Initialize()
        {
            await _gameplayFactory.CreateHud();
            await _gameplayFactory.CreatePlayerCharacter(GameObject.FindWithTag(PlayerCharacterStartPoint).transform.position);
        }
    }
}
