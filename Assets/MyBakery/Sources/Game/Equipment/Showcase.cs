﻿using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal class Showcase : MonoBehaviour, IGivable
    {
        private const int MaxItemsCount = 9;

        [SerializeField] private Stack _stack;
        [SerializeField] private ItemType _itemType;

        private List<Stackable> _items = new();

        public ItemType Type => _itemType;

        public bool TryGive(Stackable item)
        {
            if (_items.Count >= MaxItemsCount || item == null)
                return false;

            _items.Add(item);
            _stack.Add(item);

            return true;
        }

        public bool TryTake(out Stackable item)
        {
            item = null;

            if (_items.Count == 0)
                return false;

            item = _items[0];

            return true;
        }
    }
}
