﻿using UnityEngine;
using UnityEngine.InputSystem;
using Virvon.MyBakery.Input;

namespace Virvon.MyBakery.Services
{
    public class JoystickInput : IInputService
    {
        private readonly GameInputAction _inputAction;

        public Vector2 Direction { get; private set; }

        public JoystickInput()
        {
            _inputAction = new GameInputAction();
            _inputAction.Enable();

            _inputAction.Player.Movement.performed += OnMove;
        }

        ~JoystickInput()
        {
            _inputAction.Player.Movement.performed -= OnMove;
            _inputAction.Disable();

            Debug.Log("Jostick input deleted");
        }

        private void OnMove(InputAction.CallbackContext ctx) =>
            Direction = ctx.ReadValue<Vector2>();
    }
}