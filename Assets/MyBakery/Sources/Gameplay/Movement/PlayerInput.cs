using UnityEngine;
using Virvon.MyBakery.Services;
using Virvon.MyBakery.Services.Input;
using Zenject;

namespace Virvon.MyBakery.Movement
{
    internal class PlayerInput : MonoBehaviour, IInputSource
    {
        private IInputService _input;

        public Vector2 Direction => _input.Direction;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _input = inputService;
        }
    }
}