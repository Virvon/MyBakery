using UnityEngine;

namespace Virvon.MyBackery.Equipment
{
    internal class Cooker : Equipment
    {
        private const float Cooldown = 3;
        private const int MaxItemsCount = 5;

        private float time;

        public int ItemsCount { get; private set; }

        private void Update()
        {
            if (ItemsCount >= MaxItemsCount)
                return;

            time += Time.deltaTime;

            if (time > Cooldown)
            {
                time = 0;

                ItemsCount++;
            }
        }

        protected override void ShowInfo()
        {
            Debug.Log("Items count: " + ItemsCount + "/" + MaxItemsCount);
        }
    }
}
