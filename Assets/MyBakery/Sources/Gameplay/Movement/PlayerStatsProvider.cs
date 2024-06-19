using UnityEngine;
using Virvon.MyBakery.StatsDecorator;

namespace Virvon.MyBakery.Movement
{
    public class PlayerStatsProvider : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        public IStatsProvider StatsProvider { get; private set; }

        private void Awake() => 
            StatsProvider = new DefaultStats(_movementSpeed);
    }
}