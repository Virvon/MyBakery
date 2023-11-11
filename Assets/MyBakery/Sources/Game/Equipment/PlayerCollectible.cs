using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Virvon.MyBackery.Items;
using Stack = Virvon.MyBackery.Items.Stack;

namespace Virvon.MyBackery.Equipment
{
    internal class PlayerCollectible : MonoBehaviour
    {
        private const int MaxItemsCount = 3;
        private const float OperationCooldown = 1;

        [SerializeField] private Stack _stack;
        [SerializeField] private EquipmentType[] _take;
        [SerializeField] private EquipmentType[] _give;

        private List<Stackable> _items = new();
        private bool _takerIsStarted = false;
        private bool _giverIsStarted = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IGivable givable))
            {
                StartCoroutine(Taker(givable));
                StartCoroutine(Giver(givable));
            }
            else if (other.TryGetComponent(out ITakable takable))
            {
                StartCoroutine(Taker(takable));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ITakable takable))
            {
                _takerIsStarted = false;
                _giverIsStarted = false;
            }
        }

        private Stackable GetItem(ItemType type) =>
            _items.FirstOrDefault(item => item.Type == type);

        private void Take(ITakable takable)
        {
            if (_items.Count < MaxItemsCount && _take.Any(type => type == takable.Type))
            {
                if (takable.TryTake(out Stackable item))
                {
                    _items.Add(item);
                    _stack.Add(item);
                }
            }
        }

        private void Give(IGivable givable)
        {
            if (_give.Any(type => type == givable.Type) == false)
                return;

            Stackable item = GetItem(givable.ItemType);

            if (givable.TryGive(item))
                _items.Remove(item);
        }

        private IEnumerator Giver(IGivable givable)
        {
            _giverIsStarted = true;

            while(_giverIsStarted)
            {
                yield return new WaitForSeconds(OperationCooldown);

                if(_giverIsStarted)
                    Give(givable);
            }
        }

        private IEnumerator Taker(ITakable takable)
        {
            _takerIsStarted = true;

            while (_takerIsStarted)
            {
                yield return new WaitForSeconds(OperationCooldown);

                if (_takerIsStarted)
                    Take(takable);
            }
        }
    }
}
