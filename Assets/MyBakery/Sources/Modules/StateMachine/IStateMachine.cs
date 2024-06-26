﻿using Cysharp.Threading.Tasks;
using System;

namespace Virvon.StateMachineModul
{
    public interface IStateMachine
    {
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
        UniTask Enter<TState>() where TState : class, IState;
        void RegisterState<TState>(TState state) where TState : IExitableState;
    }
}