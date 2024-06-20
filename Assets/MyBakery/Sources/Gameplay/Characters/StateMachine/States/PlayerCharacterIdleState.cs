using UnityEngine;
using Virvon.MyBakery.Services.Input;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacterIdleState : IState
    {
        private readonly IInputService _inputService;
        private readonly PlayerCharacterStateMachine _stateMachine;

        public PlayerCharacterIdleState(IInputService inputService, PlayerCharacterStateMachine stateMachine)
        {
            _inputService = inputService;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter idle state");
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            if (_inputService.Direction != Vector2.zero)
                _stateMachine.Enter<PlayerCharacterMovementState>();
        }
    }
}