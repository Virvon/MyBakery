using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Virvon.MyBakery.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClientInput : MonoBehaviour, IInputSource
    {
        private NavMeshPath _path;
        private NavMeshAgent _agent;

        public Vector2 Direction { get; private set; }

        public event Action Activated;
        public event Action Deactivated;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _path = new();
        }

        public void SetTarget(Vector3 targetPosition, Action callback)
        {
            StartCoroutine(DirectionCalculater(targetPosition, callback));
        }

        private IEnumerator DirectionCalculater(Vector3 targerPosition, Action callback)
        {
            bool isFinish = false;

            Activated?.Invoke();

            while (isFinish == false)
            {
                _agent.CalculatePath(targerPosition, _path);

                while ((_path.corners[1] - _agent.transform.position).magnitude > 1.2f)
                {
                    Vector3 direction = (_path.corners[1] - _path.corners[0]).normalized;
                    Direction = new Vector2(direction.x, direction.z);

                    Debug.Log(_agent.transform.position + " | " + _path.corners[1] + " | " + (_path.corners[1] - _agent.transform.position).magnitude);

                    yield return null;
                }

                yield return null;
            }

            Deactivated?.Invoke();
            callback?.Invoke();
        }
    }
}