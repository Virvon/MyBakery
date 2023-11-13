﻿using System;
using UnityEngine;

namespace Virvon.MyBackery.Services
{
    public interface IInputService : IService
    {
        Vector2 Direction { get; }

        public event Action Activated;
        public event Action Deactivated;
    }
}
