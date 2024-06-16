using Cysharp.Threading.Tasks;
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

        private readonly IUIFactory _uiFactory;
        private readonly IPlayerFactory _playerFactory;

        public LoadGameLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingPanel loadingPanel, IUIFactory uiFactory, IPlayerFactory playerFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingPanel = loadingPanel;

            _uiFactory = uiFactory;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            _uiFactory.Load();
            _playerFactory.Load();

            _loadingPanel.Open();
            _sceneLoader.Load(GameScene, callback: OnLoaded);
        }

        public void Exit() =>
            _loadingPanel.Close();

        UniTask IState.Enter()
        {
            throw new System.NotImplementedException();
        }

        UniTask IExitableState.Exit()
        {
            throw new System.NotImplementedException();
        }

        private void OnLoaded()
        {
            _uiFactory.CreateCanvas();
            _uiFactory.CreateHud();
            _playerFactory.Create();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}