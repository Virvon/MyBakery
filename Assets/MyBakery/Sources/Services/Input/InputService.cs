using UnityEngine;

namespace Virvon.MyBakery.Services
{
    public class InputService : IInputService
    {
        public InputService()
        {
            Debug.Log("InputService");
        }

        public Vector2 Direction => Joystick.Direction;
    }
}