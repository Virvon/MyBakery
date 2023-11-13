using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

internal class BootstrapState : IState
{
    private const string InitScene = "Boot";
    private const string GameScene = "Game";

    private readonly StateMachine _stateMachine;
    private readonly AllServices _services;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(StateMachine stateMachine, AllServices services, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _services = services;

        RegisterServices();
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        _sceneLoader.Load(InitScene, callback: EnterLoadScene);
    }

    public void Exit()
    {
        
    }

    private void RegisterServices()
    {
        _services.RegisterSingle<IInputService>(new InputService());
    }

    private void EnterLoadScene() =>
            _stateMachine.Enter<LoadSceneState, string>(GameScene, _stateMachine.Enter<GameLoopState>);
}
