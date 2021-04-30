using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStill : CameraState
{
    public CameraStill(CameraManager manager, CameraStateMachine stateMachine) : base (manager, stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Cursor.lockState = CursorLockMode.None;
        manager.transform.position = Vector3.Lerp(manager.transform.position, new Vector3(0, 5, -12.5f), 0.3f);
        manager.transform.LookAt(manager.playerTransform);

        if (Input.GetMouseButtonDown(1))
        {
            stateMachine.ChangeState(manager.shoulder);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateMachine.ChangeState(manager.ocarina);
        }
    }
}
