using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine
{
    public CameraState CurrentState { get; private set; }

    public void Initialize(CameraState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(CameraState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
