using UnityEngine;
using Virvon.MyBakery.Services.Input;
using Zenject;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        public void Move(Vector2 inputDirection)
        {
            Vector3 direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            //direction = _surfaceSlider.Project(direction);

            Vector3 offset = direction * _movementSpeed * Time.deltaTime;

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