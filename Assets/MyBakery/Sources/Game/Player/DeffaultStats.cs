﻿namespace Virvon.MyBackery.Player
{
    internal class DeffaultStats : IStatsProvider
    {
        private float _movementSpeed;

        public DeffaultStats(float movementSpeed)
        {
            _movementSpeed = movementSpeed;
        }

        public PlayerStats GetStats()
        {
            return new PlayerStats()
            {
                MovementSpeed = _movementSpeed
            };
        }
    }
}
