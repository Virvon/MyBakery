using System;

namespace Virvon.StateMachineModul
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload, Action callback = null);
    }
}