using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadGameLevelState>();
        }

        public void Exit()
        {
            
        }
    }
}
