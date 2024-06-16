using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Infrustructure.AssetManagement;
using Virvon.MyBakery.UI;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;

        public GameLoadingState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            Debug.Log("Enter game loading state");

            _loadingCurtain.Show();

            await _sceneLoader.Load(InfrasructureAssetPath.GameLoadingScene);

            _loadingCurtain.Hide();
        }

        public UniTask Exit()
        {
            return default;
        }
    }
}
