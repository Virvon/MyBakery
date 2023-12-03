using Virvon.MyBackery.Services;
using Virvon.StateMachineModul;

internal class BootstrapState : IState
{
    private const string InitScene = "Boot";
    private const string GameScene = "Game";

    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;

        //RegisterServices();
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
        
    }

    private void EnterLoadScene() =>
            _stateMachine.Enter<LoadSceneState, string>(GameScene, _stateMachine.Enter<GameLoopState>);
}
