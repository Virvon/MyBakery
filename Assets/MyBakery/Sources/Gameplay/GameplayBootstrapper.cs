using UnityEngine;
using Virvon.MyBakery.Infrustructure;
using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class GameplayBootstrapper : IInitializable
    {
        public readonly IGameplayFactory _gameplayFactory;

        public GameplayBootstrapper(IGameplayFactory gameplayFactory)
        {
            _gameplayFactory = gameplayFactory;
        }

        public async void Initialize()
        {
            await _gameplayFactory.CreateHud();
        }
    }
}
