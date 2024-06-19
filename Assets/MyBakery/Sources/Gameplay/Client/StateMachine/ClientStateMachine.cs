using System;
using System.Collections.Generic;
using UnityEngine;
using Virvon.MyBakery.Equipment;
using Virvon.MyBakery.Movement;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Client
{
    public class ClientStateMachine : StateMachine
    {
        public ClientStateMachine(TestQueue testQueue, ClientInput input)
        {
            Debug.Log("Client state machine");

            //_states = new Dictionary<Type, IExitableState>
            //{
            //    [typeof(QueueEntryState)] = new QueueEntryState(this, testQueue),
            //    [typeof(MovementState)] = new MovementState(input)
            //};
        }
    }
}
