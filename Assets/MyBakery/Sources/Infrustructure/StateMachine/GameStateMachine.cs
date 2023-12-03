using System;
using System.Collections.Generic;
using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

namespace Virvon.Infrustructure
{
    internal class GameStateMachine : StateMachine
    {
        public GameStateMachine(IClientFactory clientFactory, SceneLoader sceneLoader, LoadingPanel loadingPanel)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadSceneState)] = new LoadSceneState(sceneLoader, loadingPanel),
                [typeof(GameLoopState)] = new GameLoopState(clientFactory)
            };
        }
    }
}