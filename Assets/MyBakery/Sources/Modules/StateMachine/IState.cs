using Cysharp.Threading.Tasks;

namespace Virvon.StateMachineModul
{
    public interface IState : IExitableState
    {
        UniTask Enter();
    }
}