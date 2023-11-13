using UnityEngine;

namespace Virvon.Infrustructure
{
    internal class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private LoadingPanel _loadingPanelPrefab;

        private Game _game;

        private void Awake()
        {
            _game = new Game(Instantiate(_loadingPanelPrefab));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }

}