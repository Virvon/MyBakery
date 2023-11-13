using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal interface IQueueable
    {
        void Inform();
    }

    internal class EquipmentQueue : MonoBehaviour
    {
        [SerializeField] private Transform[] _places;

        private Queue<IQueueable> _queueables = new();
        private Dictionary<IQueueable, Transform> _occupiedPlaces = new();

        public bool TrySignUp(IQueueable queueable, out Vector3 position)
        {
            Transform[] availablePlaces = _places.Except(_occupiedPlaces.Values).ToArray();

            if (availablePlaces.Length == 0)
            {
                position = Vector3.zero;
                return false;
            }

            Transform place = availablePlaces[Random.Range(0, availablePlaces.Length)];

            _queueables.Enqueue(queueable);
            _occupiedPlaces.Add(queueable, place);

            position = place.position;

            return true;
        }

        public void SignOut(IQueueable queueable)
        {

        }
    }

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
