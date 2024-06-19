using UnityEngine;
using Virvon.MyBakery.Infrustructure.States;
using Zenject;

namespace Virvon.MyBakery.Infrustructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadLevelState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameLoopState>());

#pragma warning disable CS4014
            _gameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}