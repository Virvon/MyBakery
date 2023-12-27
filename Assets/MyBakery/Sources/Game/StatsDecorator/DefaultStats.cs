namespace Virvon.MyBakery.StatsDecorator
{
    public class DefaultStats : IStatsProvider
    {
        private float _movementSpeed;

        public DefaultStats(float movementSpeed)
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
