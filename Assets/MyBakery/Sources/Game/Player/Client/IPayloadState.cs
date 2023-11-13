using System;

internal interface IPayloadState<TPayload> : IExitableState
{
    void Enter(TPayload payload, Action callback = null);
}
