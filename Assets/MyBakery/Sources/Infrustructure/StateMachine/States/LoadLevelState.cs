using Assets.MyBakery.Sources.Infrustructure.SceneMenegment;
using Assets.MyBakery.Sources.UI.LoadingCurtain;
using Cysharp.Threading.Tasks;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter(string payload)
        {
            _loadingCurtain.Show();
            await _sceneLoader.Load(payload);
            _stateMachine.Enter<GameLoopState>().Forget();
        }

        public async UniTask Exit() =>
            _loadingCurtain.Hide();
    }
}
