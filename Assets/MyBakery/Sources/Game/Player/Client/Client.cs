using UnityEngine;
using UnityEngine.AI;

namespace Virvon.MyBackery.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    internal class Client : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private NavMeshPath _path;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _path = new ();

            _agent.CalculatePath(_target.position, _path);

            Debug.Log(_path.corners.Length);
        }
    }
}