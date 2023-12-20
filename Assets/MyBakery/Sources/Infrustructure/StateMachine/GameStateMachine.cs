using System;
using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.StateMachineModul;
using Zenject;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameStateMachine : StateMachine, IInitializable
    {
        private readonly StateFactory _stateFactory;

        public GameStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
                [typeof(LoadGameLevelState)] = _stateFactory.CreateState<LoadGameLevelState>(),
                [typeof(GameLoopState)] = _stateFactory.CreateState<GameLoopState>()
            };

            Enter<BootstrapState>();
        }
    }
}