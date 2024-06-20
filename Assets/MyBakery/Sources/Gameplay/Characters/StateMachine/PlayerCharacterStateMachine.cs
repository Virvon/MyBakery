using System;
using System.Collections.Generic;
using UnityEngine;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacterStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _currentState;

        public PlayerCharacterStateMachine() =>
            _states = new();

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void RegisterState<TState>(TState state) where TState : IState =>
            _states.Add(typeof(TState), state);

        public void UpdateCurrentState() =>
            _currentState.Update();

        private TState GetState<TState>() where TState : class, IState =>
                _states[typeof(TState)] as TState;

        private TState ChangeState<TState>() where TState : class, IState
        {
            if (_currentState != null)
                _currentState.Exit();

            TState state = GetState<TState>();

            _currentState = state;

            return state;
        }
    }
}