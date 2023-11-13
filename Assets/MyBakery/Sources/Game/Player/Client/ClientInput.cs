using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Virvon.MyBackery.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    internal class ClientInput : MonoBehaviour, IInputSource
    {
        [SerializeField] private Transform _target;

        private NavMeshPath _path;
        private NavMeshAgent _agent;

        public Vector2 Direction { get; private set; }

        public event Action Activated;
        public event Action Deactivated;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _path = new();

            StartCoroutine(DirectionCalculate());
        }

        private IEnumerator DirectionCalculate()
        {
            Activated?.Invoke();
            bool isFinish = false;

            while (isFinish == false)
            {
                _agent.CalculatePath(_target.position, _path);

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
        }
    }
}