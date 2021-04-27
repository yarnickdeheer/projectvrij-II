using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject musicBulletPrefab;
    public GameObject reticle;
    public float zoomMouseSensitivity;
    private float xRotation = 0f;
    private float yRotation = 0f;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButton(1))
        {
            xRotation = transform.localRotation.eulerAngles.x;
            yRotation = transform.localRotation.eulerAngles.y;
            reticle.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * zoomMouseSensitivity * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * zoomMouseSensitivity * Time.fixedDeltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;
            //xRotation = Mathf.Clamp(xRotation, -45f, 45f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

            Vector3 overShoulder = playerTransform.position + transform.right + Vector3.up - new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
            if (Vector3.Distance(transform.position, overShoulder) < 0.1f)
            {
                transform.position = overShoulder;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, overShoulder, 0.3f);
            }
        }

        else
        {
            reticle.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 5, -12.5f), 0.3f);
            transform.LookAt(playerTransform);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            GameObject temp = Instantiate(musicBulletPrefab, (playerTransform.position + playerTransform.forward), new Quaternion(0, 0, 0, 0));
            temp.GetComponent<Rigidbody>().AddForce((playerTransform.forward + transform.forward).normalized * 1000);
        }
    }
}
