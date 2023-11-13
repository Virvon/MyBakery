using Virvon.MyBackery.Services;

namespace Virvon.Infrustructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(LoadingPanel loadingPanel)
        {
            StateMachine = new GameStateMachine(AllServices.Instance, new SceneLoader(), loadingPanel);
        }
    }
}