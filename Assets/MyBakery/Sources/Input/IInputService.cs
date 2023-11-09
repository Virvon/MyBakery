using UnityEngine;

public interface IInputService
{
    Vector2 Direction { get; }
}

public class InputService : IInputService
{
    public Vector2 Direction { get; private set; }
}