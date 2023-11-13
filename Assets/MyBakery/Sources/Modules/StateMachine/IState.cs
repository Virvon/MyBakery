namespace Virvon.StateMachineModul
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}