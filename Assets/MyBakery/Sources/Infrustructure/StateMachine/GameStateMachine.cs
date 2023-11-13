using System;
using System.Collections.Generic;
using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

namespace Virvon.Infrustructure
{
    public class GameStateMachine : StateMachine
    {
        public GameStateMachine(AllServices services, SceneLoader sceneLoader, LoadingPanel loadingPanel)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services, sceneLoader),
                [typeof(LoadSceneState)] = new LoadSceneState(sceneLoader, loadingPanel),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }
    }
}