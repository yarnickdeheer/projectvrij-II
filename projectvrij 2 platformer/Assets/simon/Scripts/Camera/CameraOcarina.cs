using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOcarina : CameraState
{
    public CameraOcarina(CameraManager manager, CameraStateMachine stateMachine) : base(manager, stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        manager.playerScript.enabled = false;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        manager.transform.position = Vector3.Lerp(manager.transform.position, manager.playerTransform.position + manager.playerTransform.forward * 10, 0.3f);
        manager.transform.LookAt(manager.playerTransform);

        if (Input.GetKeyDown(KeyCode.W))
        {
            manager.aboveText.text += "W ";
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            manager.aboveText.text += "A ";
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.aboveText.text += "S ";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            manager.aboveText.text += "D ";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateMachine.ChangeState(manager.still);
        }
    }

    public override void Exit()
    {
        base.Exit();
        manager.playerScript.enabled = true;
        manager.aboveText.text = " ";
    }
}
