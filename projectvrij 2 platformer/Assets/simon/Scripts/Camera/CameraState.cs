using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState
{
    protected CameraStateMachine stateMachine;
    protected CameraManager manager;

    protected CameraState(CameraManager manager, CameraStateMachine stateMachine)
    {
        this.manager = manager;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
