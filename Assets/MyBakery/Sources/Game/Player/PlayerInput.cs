using System;
using UnityEngine;
using Virvon.Infrustructure;
using Virvon.MyBackery.Services;

namespace Virvon.MyBackery.Player
{
    internal class PlayerInput : MonoBehaviour, IInputSource
    {
        private IInputService _input;

        public Vector2 Direction => _input.Direction;

        public event Action Activated;
        public event Action Deactivated;

        private void Awake()
        {
            //_input = Game.InputService;

            //_input.Activated += () => Activated?.Invoke();
            //_input.Deactivated += () => Deactivated?.Invoke();
        }
    }
}