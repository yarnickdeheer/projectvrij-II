using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcontroller : MonoBehaviour
{
    private bool groundedPlayer;

    CharacterController Controller;
    private Vector3 playerVelocity;
    public float Speed;
    public float jumpHeight = 5.0f;
    public Transform Cam;
    public bool ground;
    private float gravityValue = -9.81f;
    public bool dubblejump;

    public Sprite[] sprites;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

        Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = Controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
        }


        // Controller.Move(Movement);



        if (Input.GetButtonDown("Jump") && ground == true)
        {
            Debug.Log("jump");
            ground = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }
        else if (Input.GetButtonDown("Jump") && dubblejump == true)
        {
            dubblejump = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Controller.Move(playerVelocity * Time.deltaTime);



        Vector3 targetPostition = new Vector3(target.position.x,
                                     this.transform.position.y,
                                     target.position.z);
        this.transform.LookAt(targetPostition);
        
    }



    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;


        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Controller.Move(Movement);
        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().Xsensivity * Time.deltaTime);


            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }







        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
           
            ground = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
           
            ground = true;

        }
    }
}
