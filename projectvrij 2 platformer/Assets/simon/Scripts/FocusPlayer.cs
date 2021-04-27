using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    public float playerMoveSpeed = 10f;
    private Rigidbody rb;
    public GameObject groundCheckObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        /*        transform.LookAt(new Vector3(transform.position.x + Input.GetAxis("Horizontal"),transform.position.y, transform.position.z + Input.GetAxis("Vertical")));

                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                    transform.position = transform.position + transform.forward * Time.deltaTime * playerMoveSpeed;*/


        //we gotta move in tandem with the camera view
        Vector3 lastPos = transform.position;

        if(Input.GetAxis("Vertical") != 0)
        {
            transform.position = transform.position + (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = transform.position + (Camera.main.transform.right.normalized * Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed);
        }

        if (Input.GetMouseButton(1))
        {
            transform.forward = Camera.main.transform.forward;
        }

        else
        {
            Vector3 newPos = transform.position;
            transform.LookAt(transform.position + (newPos - lastPos));
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheckObject.GetComponent<groundcheck>().groundTrigger)
        {
            rb.AddForce(Vector3.up * 300); 
        }
    }
}
