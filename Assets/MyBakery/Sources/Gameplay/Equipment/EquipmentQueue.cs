using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Virvon.MyBakery.Equipment
{
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
}
