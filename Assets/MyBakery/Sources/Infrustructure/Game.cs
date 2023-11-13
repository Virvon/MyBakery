using Virvon.MyBackery.Services;

namespace Virvon.Infrustructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine(AllServices.Instance);
        }
    }
}