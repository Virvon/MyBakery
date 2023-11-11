using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{

    internal class Cooker : MonoBehaviour, ITakable
    {
        private const float CookingCooldown = 3;
        private const int MaxItemsCount = 5;

        [SerializeField] private EquipmentType _type;
        [SerializeField] private Stack _stack;
        [SerializeField] private Item _item;

        private float time;
        private List<Stackable> _items = new ();

        public EquipmentType Type => _type;

        public bool TryTake(out Stackable item)
        {
            item = null;

            if(_items.Count == 0)
                return false;

            item = _items[0];
            _items.Remove(item);

            return true;
        }

        private void Update()
        {
            if (_items.Count >= MaxItemsCount)
                return;

            time += Time.deltaTime;

            if (time >= CookingCooldown)
            {
                time = 0;


                Item item = Instantiate(_item);

                _items.Add(item);
                _stack.Add(item);
            }
        }
    }
}
