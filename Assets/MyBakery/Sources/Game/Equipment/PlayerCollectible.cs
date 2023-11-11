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

        private List<Stackable> _items = new();
        private bool _operationIsStarted = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IGivable givable))
                StartCoroutine(Giver(givable));
            else if (other.TryGetComponent(out ITakable takable))
                StartCoroutine(Taker(takable));
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ITakable takaable))
                _operationIsStarted = false;
        }

        private Stackable GetItem(ItemType type) =>
            _items.FirstOrDefault(item => item.Type == type);

        private void Take(ITakable takable)
        {
            if (_items.Count < MaxItemsCount)
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
            Stackable item = GetItem(givable.Type);

            if (givable.TryGive(item))
                _items.Remove(item);
        }

        private IEnumerator Giver(IGivable givable)
        {
            _operationIsStarted = true;

            while(_operationIsStarted)
            {
                yield return new WaitForSeconds(OperationCooldown);

                if(_operationIsStarted)
                {
                    Take(givable);
                    Give(givable);
                }
            }
        }

        private IEnumerator Taker(ITakable takable)
        {
            _operationIsStarted = true;

            while (_operationIsStarted)
            {
                yield return new WaitForSeconds(OperationCooldown);

                if (_operationIsStarted)
                    Take(takable);
            }
        }
    }
}
