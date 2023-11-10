using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal class Cooker : Equipment
    {
        private const float CookingCooldown = 3;
        private const int MaxItemsCount = 5;
        private const float GivingCooldown = 1;

        [SerializeField] private Stack _stack;
        [SerializeField] private Item _item;

        private float time;
        private bool _isCollectibleInZone;
        private int _itemsCount;
        private List<Stackable> _items = new ();

        private void Update()
        {
            if (_itemsCount >= MaxItemsCount)
                return;

            time += Time.deltaTime;

            if (time > CookingCooldown)
            {
                time = 0;

                _itemsCount++;

                Item item = Instantiate(_item);

                _items.Add(item);
                _stack.Add(item);
            }
        }

        protected override void SetCollectible(ICollectible collectible)
        {
            _isCollectibleInZone = true;
            StartCoroutine(Giver(collectible));
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
                    if (collectible.TryGiveItem(_items[0]))
                    {
                        _itemsCount--;
                        _items.Remove(_items[0]);
                    }
                }
            }
        }
    }
}
