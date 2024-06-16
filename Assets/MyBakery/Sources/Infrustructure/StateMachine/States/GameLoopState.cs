using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameLoopState : IState
    {
        public UniTask Enter()
        {
            Debug.Log("Eneter Game loop state");
            return default;
        }

        public UniTask Exit()
        {
            return default;
        }
    }
}
