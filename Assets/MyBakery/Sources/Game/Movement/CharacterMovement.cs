using System.Collections;
using UnityEngine;
using Virvon.MyBakery.StatsDecorator;

namespace Virvon.MyBakery.Movement
{

    [RequireComponent(typeof(SurfaceSlider), typeof(Rigidbody), typeof(IInputSource))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed = 1080;

        private bool _isMoving; 
        private SurfaceSlider _surfaceSlider;
        private Rigidbody _rigidbody;
        private Coroutine _mover;
        private IInputSource _input;

        public IStatsProvider StatsProvider { get; private set; }

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
            _input = GetComponent<IInputSource>();

            StatsProvider = new DeffaultStats(_movementSpeed);

            _input.Activated += OnActivated;
            _input.Deactivated += OnDeactivated;
        }

        private void OnDisable()
        {
            _input.Activated -= OnActivated;
            _input.Deactivated -= OnDeactivated;
        }

        private void OnActivated()
        {
            if (_mover != null)
                StopCoroutine(_mover);

            _isMoving = true;
            _mover = StartCoroutine(Mover());
        }

        private void OnDeactivated() =>
            _isMoving = false;

        private void RotateTo(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        private IEnumerator Mover()
        {
            while (_isMoving)
            {
                Vector3 direction = new Vector3(_input.Direction.x, 0, _input.Direction.y);
                direction = _surfaceSlider.Project(direction);

                Vector3 offset = direction * StatsProvider.GetStats().MovementSpeed * Time.deltaTime;

                _rigidbody.MovePosition(_rigidbody.position + offset);

                RotateTo(direction);

                yield return null;
            }
        }
    }
}