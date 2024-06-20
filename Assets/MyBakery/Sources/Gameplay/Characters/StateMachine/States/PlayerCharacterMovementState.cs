using UnityEngine;
using Virvon.MyBakery.Services.Input;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacterMovementState : IState
    {
        private readonly PlayerCharacterStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly PlayerCharacterMovement _playerCharacterMovement;

        public PlayerCharacterMovementState(PlayerCharacterStateMachine stateMachine, IInputService inputService, PlayerCharacterMovement playerCharacterMovement)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _playerCharacterMovement = playerCharacterMovement;
        }

        public void Enter()
        {
            Debug.Log("Enter movement state");
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_inputService.Direction == Vector2.zero)
            {
                _stateMachine.Enter<PlayerCharacterIdleState>();
                return;
            }

            _playerCharacterMovement.Move(_inputService.Direction);
        }
    }
}