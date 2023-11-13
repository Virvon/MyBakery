using UnityEngine;

namespace Virvon.MyBackery.Player
{

    [RequireComponent(typeof(IInputSource))]
    internal class Client : MonoBehaviour
    {
        private IInputSource _input;

        private void Start()
        {
            _input = GetComponent<IInputSource>();
        }
    }
}