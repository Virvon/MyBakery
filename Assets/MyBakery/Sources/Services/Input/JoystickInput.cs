using UnityEngine;
using UnityEngine.InputSystem;
using Virvon.MyBakery.Input;

namespace Virvon.MyBakery.Services.Input
{
    public class JoystickInput : IInputService
    {
        private readonly GameInputAction _inputAction;

        public Vector2 Direction { get; private set; }

        public JoystickInput()
        {
            _inputAction = new GameInputAction();
            _inputAction.Enable();

            _inputAction.Player.Movement.performed += OnPerformed;
            _inputAction.Player.Movement.canceled += OnCancele;
        }

        ~JoystickInput()
        {
            _inputAction.Player.Movement.performed -= OnPerformed;
            _inputAction.Player.Movement.performed -= OnCancele;
            _inputAction.Disable();
        }

        private void OnPerformed(InputAction.CallbackContext ctx) =>
            Direction = ctx.ReadValue<Vector2>();

        private void OnCancele(InputAction.CallbackContext ctx) =>
            Direction = Vector2.zero;
    }
}