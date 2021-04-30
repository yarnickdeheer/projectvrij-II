using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShoulder : CameraState
{
    public CameraShoulder(CameraManager manager, CameraStateMachine stateMachine) : base(manager, stateMachine)
    {

    }
    public float zoomMouseSensitivity = 100f;
    private float xRotation;
    private float yRotation;
    private int instrumentMode;
   // private float bulletSize = 0.1f;

    public override void Enter()
    {
        base.Enter();
        manager.reticle.SetActive(true);
        xRotation = manager.transform.localRotation.eulerAngles.x;
        yRotation = manager.transform.localRotation.eulerAngles.y;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        manager.reticle.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * zoomMouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * zoomMouseSensitivity * Time.fixedDeltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        manager.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        Vector3 overShoulder = Vector3.zero;


        if (instrumentMode == 0)
            overShoulder = manager.playerTransform.position + manager.transform.right * 2 + Vector3.up - new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;

        if (instrumentMode == 1)
            overShoulder = manager.playerTransform.position + manager.playerTransform.forward / 3 + Vector3.up / 3;

        if(instrumentMode == 2)
            overShoulder = manager.playerTransform.position - manager.playerTransform.forward - manager.playerTransform.right + Vector3.up;

        if (Vector3.Distance(manager.transform.position, overShoulder) < 0.1f)
        {
            manager.transform.position = overShoulder;
        }
        else
        {
            manager.transform.position = Vector3.Lerp(manager.transform.position, overShoulder, 0.3f);
        }

/*        if (Input.GetKeyDown(KeyCode.Z))
            bulletSize = 0.2f;*/


        if (Input.GetMouseButtonDown(0))
        {
            manager.shootMusic();
        }

        if (Input.GetMouseButtonUp(1))
        {
            //bulletSize = 0.1f;
            stateMachine.ChangeState(manager.still);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(instrumentMode >= 2)
            {
                instrumentMode = 0;
            }
            else
            {
                instrumentMode++;
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        manager.reticle.SetActive(false);
    }


}
