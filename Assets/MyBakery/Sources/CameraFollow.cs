using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    private Vector3 _startOffset;

    //[Inject]
    //private void Construct(Player targer)
    //{
    //    _target = targer.transform;
    //    _startOffset = transform.position - _target.position;
    //}

    private void LateUpdate()
    {
        transform.position = _startOffset + _target.position;
    }
}