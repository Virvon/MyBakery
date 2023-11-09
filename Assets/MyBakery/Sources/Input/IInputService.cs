using System;
using UnityEngine;

public interface IInputService
{
    Vector2 Direction { get; }

    public event Action Activated;
    public event Action Deactivated;
}
