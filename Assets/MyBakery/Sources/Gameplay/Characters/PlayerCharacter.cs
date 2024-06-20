using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Services.Input;
using Zenject;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacter : MonoBehaviour
    {
        private PlayerCharacterStateMachine _stateMachine;
        private IInputService _inputService;
        private StatesFactory _statesFactory;

        [Inject]
        private void Construct(StatesFactory statesFactory, PlayerCharacterStateMachine stateMachine, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _statesFactory = statesFactory;
        }

        private void Start()
        {
            _stateMachine.RegisterState(_statesFactory.Create<PlayerCharacterIdleState>());
            _stateMachine.RegisterState(_statesFactory.Create<PlayerCharacterMovementState>());

            _stateMachine.Enter<PlayerCharacterIdleState>();
        }

        private void Update() =>
            _stateMachine.UpdateCurrentState();

        public class Factory : PlaceholderFactory<string, UniTask<PlayerCharacter>>
        { 
        }
    }
}