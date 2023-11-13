using System;
using UnityEngine;

internal class MovementState : IPayloadState<Vector3>
{
    private readonly ICoroutineRunner _coroutineRunner;

    public MovementState(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void Enter(Vector3 payload, Action callback = null)
    {
        
    }

    public void Exit()
    {
        
    }
}
