using UnityEngine;

namespace Virvon.MyBakery.Equipment
{
    public class TestQueue : MonoBehaviour
    {
        [SerializeField] private Transform[] _positions;

        public Transform GetPoint()
        {
            return _positions[Random.Range(0, _positions.Length)];
        }
    }
}
