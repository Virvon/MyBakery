using System;

namespace Virvon.StateMachineModul
{
    public interface IStateMachine
    {
        void Enter<TState, TPayload>(TPayload payload, Action callback = null) where TState : class, IPayloadState<TPayload>;
        void Enter<TState>() where TState : class, IState;
    }
}