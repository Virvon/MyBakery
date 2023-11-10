using System.Collections;
using UnityEngine;

namespace Virvon.MyBackery.Equipment
{
    internal class Showcase : Equipment
    {
        private const int MaxItemsCount = 9;
        private const float TakingCooldown = 1;

        private bool _isCollectibleInZone;
        private int _itemsCount;

        protected override void RemoveCollectible()
        {
            _isCollectibleInZone = false;
        }

        protected override void SetCollectible(ICollectible collectible)
        {
            _isCollectibleInZone = true;
            StartCoroutine(Taker(collectible));
        }

        protected override void ShowInfo()
        {
            Debug.Log("Itmes count: " + _itemsCount + "/" + MaxItemsCount);
        }

        private IEnumerator Taker(ICollectible collectible)
        {
            while (_isCollectibleInZone)
            {
                yield return new WaitForSeconds(TakingCooldown);

                if (_itemsCount < MaxItemsCount && _isCollectibleInZone)
                {
                    if (collectible.TryTakeItem())
                        _itemsCount++;
                }
            }
        }
    }
}
