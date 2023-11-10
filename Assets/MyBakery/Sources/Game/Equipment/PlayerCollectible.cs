using UnityEngine;

namespace Virvon.MyBackery.Equipment
{
    internal class PlayerCollectible : MonoBehaviour, ICollectible
    {
        private const int MaxItemsCount = 3;

        private int _itemsCount;

        public bool TryGiveItem()
        {
            if (_itemsCount >= MaxItemsCount)
                return false;

            _itemsCount++;

            Debug.Log("Collect: " + _itemsCount);

            return true;
        }

        public bool TryTakeItem()
        {
            if (_itemsCount <= 0)
                return false;

            _itemsCount--;

            Debug.Log("Give: " + _itemsCount);

            return true;
        }
    }
}
