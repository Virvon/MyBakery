using Cysharp.Threading.Tasks;
using UnityEngine;
using Virvon.MyBakery.Equipment;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Client
{
    public class QueueEntryState : IState
    {
        private readonly ClientStateMachine _stateMachine;
        private readonly TestQueue _queue;

        public QueueEntryState(ClientStateMachine stateMachine, TestQueue queue)
        {
            _stateMachine = stateMachine;
            _queue = queue;
        }

        public void Enter()
        {
#pragma warning disable CS4014
            _stateMachine.Enter<MovementState, Vector3>(_queue.GetPoint());
        }

        public void Exit()
        {
            
        }

        UniTask IState.Enter()
        {
            throw new System.NotImplementedException();
        }

        UniTask IExitableState.Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}


