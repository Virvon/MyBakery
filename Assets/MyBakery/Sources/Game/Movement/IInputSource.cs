using System;
using UnityEngine;

namespace Virvon.MyBackery.Movement
{
    internal interface IInputSource
    {
        Vector2 Direction { get; }

        event Action Activated;
        event Action Deactivated;
    }
}