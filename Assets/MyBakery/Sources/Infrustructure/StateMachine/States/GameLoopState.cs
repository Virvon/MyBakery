using System;
using Virvon.Infrustructure;
using Virvon.StateMachineModul;

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
