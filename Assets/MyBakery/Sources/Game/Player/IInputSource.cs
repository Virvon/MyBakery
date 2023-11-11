using System;
using UnityEngine;

namespace Virvon.MyBackery.Player
{
    internal interface IInputSource
    {
        Vector2 Direction { get; }

        event Action Activated;
        event Action Deactivated;
    }
}