using System;
using UnityEngine;

namespace Virvon.MyBakery.Services
{
    public class InputService : IInputService
    {
        public Vector2 Direction => Joystick.Direction;

        public event Action Activated;
        public event Action Deactivated;

        public InputService()
        {
            Joystick.Activated += () => Activated?.Invoke();
            Joystick.Deactivated += () => Deactivated?.Invoke();
        }
    }
}