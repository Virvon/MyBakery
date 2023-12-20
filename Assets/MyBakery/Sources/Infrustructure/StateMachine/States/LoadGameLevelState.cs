using Virvon.MyBakery.DependencyInjection.Factories;
using Virvon.MyBakery.Services;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class LoadGameLevelState : IState
    {
        private const string GameScene = "Game";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingPanel _loadingPanel;
        private readonly IPlayerFactory _playerFactory;

        public LoadGameLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingPanel loadingPanel, IPlayerFactory playerFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingPanel = loadingPanel;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            _playerFactory.Load();
            _loadingPanel.Open();
            _sceneLoader.Load(GameScene, callback: OnLoaded);
        }

        public void Exit() =>
            _loadingPanel.Close();

        private void OnLoaded()
        {
            _playerFactory.Create();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}