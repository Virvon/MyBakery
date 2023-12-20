using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Services;

namespace Virvon.MyBakery.Infrustructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(IClientFactory clientFactory, SceneLoader sceneLoader, LoadingPanel loadingPanel)
        {
            Debug.Log("Injected game");
            //StateMachine = new GameStateMachine(clientFactory, sceneLoader, loadingPanel);
        }
    }
}