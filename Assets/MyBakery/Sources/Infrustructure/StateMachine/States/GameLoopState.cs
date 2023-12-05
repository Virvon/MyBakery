using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameLoopState : IState
    {
        private IClientFactory _clientFactory;

        public GameLoopState(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}
