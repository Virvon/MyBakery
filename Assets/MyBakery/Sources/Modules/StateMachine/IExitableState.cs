using Cysharp.Threading.Tasks;

namespace Virvon.StateMachineModul
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}