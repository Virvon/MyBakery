using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _startOffset;

    private void Start()
    {
         _startOffset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        transform.position = _startOffset + _target.position;
    }
}