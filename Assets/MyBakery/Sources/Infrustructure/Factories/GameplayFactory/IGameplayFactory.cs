using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Virvon.MyBakery.Infrustructure
{
    public interface IGameplayFactory
    {
        UniTask CreateHud();
        UniTask CreatePlayerCharacter(Vector3 position);
    }
}