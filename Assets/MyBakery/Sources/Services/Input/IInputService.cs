﻿using System;
using UnityEngine;

namespace Virvon.MyBakery.Services
{
    public interface IInputService
    {
        Vector2 Direction { get; }

        public event Action Activated;
        public event Action Deactivated;
    }
}
