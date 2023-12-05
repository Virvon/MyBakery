using System;
using System.Collections.Generic;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Services;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameStateMachine : StateMachine
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