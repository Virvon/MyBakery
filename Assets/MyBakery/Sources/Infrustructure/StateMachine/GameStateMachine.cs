using System;
using System.Collections.Generic;
using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

namespace Virvon.Infrustructure
{
    public class GameStateMachine : StateMachine
    {
        public GameStateMachine(AllServices services)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(services)
            };
        }
    }
}