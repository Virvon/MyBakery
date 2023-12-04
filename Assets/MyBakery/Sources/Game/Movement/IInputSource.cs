using System;
using UnityEngine;

namespace Virvon.MyBakery.Movement
{
    internal interface IInputSource
    {
        Vector2 Direction { get; }

        event Action Activated;
        event Action Deactivated;
    }
}