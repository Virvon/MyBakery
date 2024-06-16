using Assets.MyBakery.Sources.Infrustructure;
using Assets.MyBakery.Sources.Infrustructure.AssetMenegment;
using Assets.MyBakery.Sources.Infrustructure.SceneMenegment;
using Assets.MyBakery.Sources.UI.LoadingCurtain;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure
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

        public async UniTask Exit()
        {

        }
    }
}
