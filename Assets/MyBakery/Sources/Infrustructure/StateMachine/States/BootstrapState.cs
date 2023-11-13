using System;
using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

internal class BootstrapState : IState
{
    private readonly AllServices _services;

    public BootstrapState(AllServices services)
    {
        _services = services;

        RegisterServices();
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    private void RegisterServices()
    {
        _services.RegisterSingle<IInputService>(new InputService());
    }
}