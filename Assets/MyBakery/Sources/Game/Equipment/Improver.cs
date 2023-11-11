using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal class Improver : MonoBehaviour, IGivable
    {
        private const float CookingCooldown = 3;
        private const int MaxRawsCount = 4;
        private const int MaxProductCount = 4;

        [SerializeField] private Stack _rawsStack;
        [SerializeField] private Stack _productStack;
        [SerializeField] private Item _productPrefab;
        [SerializeField] private ItemType _rawItemType;
        [SerializeField] private EquipmentType _type;

        private List<Stackable> _rawItems = new();
        private List<Stackable> _productItems = new();
        private float time;

        public ItemType ItemType => _rawItemType;

        public EquipmentType Type => _type;

        private void Update()
        {
            if (_rawItems.Count == 0 || _productItems.Count >= MaxProductCount)
                return;

            time += Time.deltaTime;

            if (time >= CookingCooldown)
            {
                Stackable productItem = Instantiate(_productPrefab);
                Stackable rawItem = _rawItems[0];

                _rawItems.Remove(rawItem);
                Destroy(rawItem.gameObject);

                _productItems.Add(productItem);
                _productStack.Add(productItem);
            }
        }

        public bool TryGive(Stackable item)
        {
            if (_rawItems.Count >= MaxRawsCount || item == null)
                return false;

            _rawItems.Add(item);
            _rawsStack.Add(item);

            return true;
        }

        public bool TryTake(out Stackable item)
        {
            item = null;

            if (_productItems.Count == 0)
                return false;

            item = _productItems[0];
            _productItems.Remove(item);

            return true;
        }
    }
}
