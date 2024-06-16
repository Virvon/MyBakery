using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Infrustructure.AssetManagement;
using Virvon.MyBakery.UI;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Infrustructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LoadingCurtainProxy _loadingCurtainProxy;
        private readonly IAssetProvider _assetProvider;

        public BootstrapState(GameStateMachine stateMachine, LoadingCurtainProxy loadingCurtainProxy, IAssetProvider assetProvider)
        {
            Debug.Log("Construct bootstrap state");
            _stateMachine = stateMachine;
            _loadingCurtainProxy = loadingCurtainProxy;
            _assetProvider = assetProvider;
        }

        public async UniTask Enter()
        {
            Debug.Log("Enter bootstrap state");

            await InitServices();

            _stateMachine.Enter<LoadLevelState, string>(InfrasructureAssetPath.GameScene).Forget();
        }

        public UniTask Exit() => 
            default;

        private async Task InitServices()
        {
            await _assetProvider.InitializeAsync();
            await _loadingCurtainProxy.InitializeAsync();
        }
    }
}
