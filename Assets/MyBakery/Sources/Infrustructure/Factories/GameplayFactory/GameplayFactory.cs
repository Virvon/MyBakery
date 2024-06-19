using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Gameplay;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private readonly HudFactory _hudFactory;

        public GameplayFactory(HudFactory hudFactory)
        {
            _hudFactory = hudFactory;
        }

        public UniTask CreateHud()
        {
            return _hudFactory.Create(GameplayFactoryAssets.Hud);
        }
    }
}
