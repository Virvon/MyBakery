using UnityEngine;
using Virvon.MyBakery.Services.Input;
using Zenject;

namespace Virvon.MyBakery.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float Epsilon = 0.01f;

        [SerializeField] private float _rotationSpeed;

        [SerializeField] private PlayerStatsProvider _player;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;

        [SerializeField] private bool y;
        
        private IInputService _inputService;
        private static int x = 1;

        private float MovementSpeed => _player.StatsProvider.GetStats().MovementSpeed;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;


            y = _inputService != null;
        }

        private void Awake()
        {

        }

        private void OnEnable()
        {
        }

        private void Start()
        {

        }

        private void Update()
        {
            if(_inputService == null)
            {
                return;
            }

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