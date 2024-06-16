using Cysharp.Threading.Tasks;
using System;

namespace Virvon.StateMachineModul
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}