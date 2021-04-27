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

        Vector3 overShoulder = manager.playerTransform.position + manager.transform.right + Vector3.up - new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        if (Vector3.Distance(manager.transform.position, overShoulder) < 0.1f)
        {
            manager.transform.position = overShoulder;
        }
        else
        {
            manager.transform.position = Vector3.Lerp(manager.transform.position, overShoulder, 0.3f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            manager.shootMusic();
        }

        if (Input.GetMouseButtonUp(1))
        {
            stateMachine.ChangeState(manager.still);
        }
    }

    public override void Exit()
    {
        base.Exit();
        manager.reticle.SetActive(false);
    }


}
