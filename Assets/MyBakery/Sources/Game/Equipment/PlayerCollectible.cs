using System.Collections.Generic;
using System.Linq;
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

        public bool TryTakeItem(ItemType type, out Stackable item)
        {
            item = _items.Where(item => item.Type == type).FirstOrDefault();

            if (item == null)
                return false;

            _items.Remove(item);

            return true;
        }
    }
}
