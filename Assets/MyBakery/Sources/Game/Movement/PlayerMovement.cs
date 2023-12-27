using UnityEngine;
using Virvon.MyBakery.Services;
using Zenject;

namespace Virvon.MyBakery.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float Epsilon = 0.01f;

        [SerializeField] private float _rotationSpeed;

        [SerializeField] private Player _player;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;

        private IInputService _inputService;

        private float MovementSpeed => _player.StatsProvider.GetStats().MovementSpeed;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;

            Debug.Log("Player movement");
        }

        private void Update()
        {
            if (_inputService.Direction.sqrMagnitude > Epsilon)
                Move();
        }

        private void Move()
        {
            Vector3 direction = new Vector3(_inputService.Direction.x, 0, _inputService.Direction.y);
            direction = _surfaceSlider.Project(direction);

            Vector3 offset = direction * MovementSpeed * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + offset);

            RotateTo(direction);
        }

        private void RotateTo(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}