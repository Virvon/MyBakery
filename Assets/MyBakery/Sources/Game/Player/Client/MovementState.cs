using System;
using UnityEngine;
using Virvon.StateMachineModul;

internal class MovementState : IPayloadState<Vector3>
{
    public event Action<Vector3, Action> Entered;

    public void Enter(Vector3 payload, Action callback = null)
    {
        Entered?.Invoke(payload, callback);
    }

    public void Exit()
    {
        
    }
}
