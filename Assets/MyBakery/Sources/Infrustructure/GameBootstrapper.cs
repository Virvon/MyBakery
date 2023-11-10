using UnityEngine;

namespace Virvon.Infrustructure
{
    internal class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();

            DontDestroyOnLoad(this);
        }
    }

}