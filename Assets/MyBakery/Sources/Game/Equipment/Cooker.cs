using System.Collections;
using UnityEngine;

namespace Virvon.MyBackery.Equipment
{
    internal class Cooker : Equipment
    {
        private const float CookingCooldown = 3;
        private const int MaxItemsCount = 5;
        private const float GivingCooldown = 1;

        private float time;
        private Coroutine _giver;
        private bool _isCollectibleInZone;
        private int _itemsCount;

        private void Update()
        {
            if (_itemsCount >= MaxItemsCount)
                return;

            time += Time.deltaTime;

            if (time > CookingCooldown)
            {
                time = 0;

                _itemsCount++;
            }
        }

        protected override void ShowInfo()
        {
            Debug.Log("Items count: " + _itemsCount + "/" + MaxItemsCount);
        }

        protected override void SetCollectible(ICollectible collectible)
        {
            _isCollectibleInZone = true;
            _giver = StartCoroutine(Giver(collectible));
        }

        protected override void RemoveCollectible()
        {
            _isCollectibleInZone = false;
        }

        private IEnumerator Giver(ICollectible collectible)
        {
            while (_isCollectibleInZone)
            {
                yield return new WaitForSeconds(GivingCooldown);

                if (_itemsCount > 0 && _isCollectibleInZone)
                {
                    if (collectible.TryGiveItem())
                        _itemsCount--;
                }
            }
        }
    }
}
