﻿using System;
using UnityEngine;
using Virvon.Infrustructure;
using Virvon.MyBackery.Services;
using Zenject;

namespace Virvon.MyBackery.Movement
{
    internal class PlayerInput : MonoBehaviour, IInputSource
    {
        private IInputService _input;

        public Vector2 Direction => _input.Direction;

        public event Action Activated;
        public event Action Deactivated;

        [Inject]
        public void Init(IInputService inputService)
        {
            _input = inputService;

            _input.Activated += () => Activated?.Invoke();
            _input.Deactivated += () => Deactivated?.Invoke();
        }

        private void OnDestroy()
        {
            _input.Activated -= () => Activated?.Invoke();
            _input.Deactivated -= () => Deactivated?.Invoke();
        }
    }
}