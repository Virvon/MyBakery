using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    internal class GameLoopState : IState
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
