using UnityEngine;

namespace Virvon.Infrustructure
{
    internal class Game
    {
        public GameStateMachine StateMachine;

        public Game(IClientFactory clientFactory, SceneLoader sceneLoader, LoadingPanel loadingPanel)
        {
            Debug.Log("Injected game");
            StateMachine = new GameStateMachine(clientFactory, sceneLoader, loadingPanel);
        }
    }
}