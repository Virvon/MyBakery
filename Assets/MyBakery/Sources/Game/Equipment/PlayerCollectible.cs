using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;

namespace Virvon.MyBackery.Equipment
{
    internal class PlayerCollectible : MonoBehaviour, ICollectible
    {
        private const int MaxItemsCount = 3;

        [SerializeField] private Stack _stack;

        private List<Stackable> _items = new();

        public bool TryGiveItem(Stackable item)
        {
            if (_items.Count >= MaxItemsCount)
                return false;

            _items.Add(item);
            _stack.Add(item);

            return true;
        }

        public bool TryTakeItem(out Stackable item)
        {
            item = null;

            if (_items.Count <= 0)
                return false;

            item = _items[0];
            _items.Remove(_items[0]);

            return true;
        }
    }
}
