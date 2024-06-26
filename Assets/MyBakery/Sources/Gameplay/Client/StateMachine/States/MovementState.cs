﻿using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Virvon.MyBakery.Movement;
using Virvon.StateMachineModul;

namespace Virvon.MyBakery.Client
{
    public class MovementState : IPayloadState<Vector3>
    {
        private ClientInput _input;

        public MovementState(ClientInput input)
        {
            _input = input;
        }

        public void Enter(Vector3 payload, Action callback = null)
        {
            _input.SetTarget(payload, callback);
        }

        public void Exit()
        {

        }

        UniTask IPayloadState<Vector3>.Enter(Vector3 payload)
        {
            throw new NotImplementedException();
        }

        UniTask IExitableState.Exit()
        {
            throw new NotImplementedException();
        }
    }
}


