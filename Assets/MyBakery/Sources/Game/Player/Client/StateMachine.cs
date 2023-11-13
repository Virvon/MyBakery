using System;
using System.Collections.Generic;

internal class StateMachine
{
    private readonly Dictionary<Type, IState> _states;

    private IExitableState _currentState;

    public void Enter<TState>() where TState : class, IState
    {
        TState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload, Action callback = null) where TState : class, IPayloadState<TPayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload, callback);
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _currentState?.Exit();

        TState state = GetState<TState>();

        _currentState = state;

        return state;
    }
}