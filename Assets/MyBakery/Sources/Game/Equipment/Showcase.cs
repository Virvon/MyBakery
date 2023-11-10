using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal class Showcase : Equipment
    {
        private const int MaxItemsCount = 9;
        private const float TakingCooldown = 1;

        [SerializeField] private Stack _stack;
        [SerializeField] private ItemType _itemType;

        private bool _isCollectibleInZone;
        private List<Stackable> _items = new();

        protected override void RemoveCollectible()
        {
            _isCollectibleInZone = false;
        }

        protected override void SetCollectible(ICollectible collectible)
        {
            _isCollectibleInZone = true;
            StartCoroutine(Taker(collectible));
        }

        private IEnumerator Taker(ICollectible collectible)
        {
            while (_isCollectibleInZone)
            {
                yield return new WaitForSeconds(TakingCooldown);

                if (_items.Count < MaxItemsCount && _isCollectibleInZone)
                {
                    if (collectible.TryTakeItem(_itemType, out Stackable item))
                    {
                        _items.Add(item);
                        _stack.Add(item);
                    }
                }
            }
        }
    }
}
