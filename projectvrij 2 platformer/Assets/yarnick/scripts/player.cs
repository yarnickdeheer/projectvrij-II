using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5;
    private float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;
    public GameObject plane;
    public bool ground;
    public Sprite[] sprites;
     public GameObject s;

    public int orbitspeed;
    public buddymechs buddy;

    public bool dubblejump;
    // public GameObject play;
    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }



        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
        }
        //if (Input.GetKeyDown(KeyCode.Space) && ground == true)
        //{
        //    Jump();
        //}
        if (Input.GetButtonDown("Jump") && ground ==true)
        {
            ground = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }else if (Input.GetButtonDown("Jump") && dubblejump == true)
        {
            dubblejump = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }
        Vector3 move = new Vector3(0f, 0.1f, Input.GetAxis("Vertical"));
   

        playerVelocity.y += gravityValue * Time.deltaTime ;
        controller.Move(playerVelocity * Time.deltaTime);



        



    }

    void Move()
    {
        //plane.transform.eulerAngles = new Vector3(
        //     plane.transform.eulerAngles.x,
        //     plane.transform.eulerAngles.y + (Input.GetAxisRaw("Horizontal") / 100),
        //     plane.transform.eulerAngles.z

        // );
        // transform.RotateAround(s.transform.position, Vector3.up, (Input.GetAxisRaw("Horizontal")));
       // transform.RotateAround(s.transform.position, Vector3.up, (-Input.GetAxisRaw("Horizontal") * 2 * Time.deltaTime));
        if (Input.GetButtonDown("Jump") && ground)
        {
            ground = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }
        else if (Input.GetButtonDown("Jump") && dubblejump == true)
        {
            dubblejump =false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
        }

        Vector3 move = new Vector3(0f, 0.1f, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

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

        //float Horizontal = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //float Vertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

         
        //Vector3 Movement =transform.forward * Vertical;
        //controller.Move(Movement);


        //float x = Input.GetAxisRaw("Vertical");
        //float moveBy = x * playerSpeed;
        //this.GetComponent<Rigidbody>().velocity = new Vector2(moveBy, this.GetComponent<Rigidbody>().velocity.z);
    }

    public void Jump()
    {
        ground = false;
        this.GetComponent<Rigidbody>().velocity = new Vector2(this.GetComponent<Rigidbody>().velocity.x, jumpHeight);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (buddy.dj == true)
            {
                dubblejump = true;
            }
               ground = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (buddy.dj == true)
            {
                dubblejump = true;
            }
            ground = true;
            
        }
    }




    //public float speed;
    //public float jumpForce;
    //Rigidbody rb;
    //bool ground;
    ////public Animator anim;
    ////public Text txt;

    //public int hp;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}


    //void Update()
    //{
    //    //if (anim.GetCurrentAnimatorStateInfo(0).IsName ("poke") || anim.GetCurrentAnimatorStateInfo(0).IsName("slash")|| anim.GetCurrentAnimatorStateInfo(0).IsName("smash") || anim.GetCurrentAnimatorStateInfo(0).IsName("uppercut"))
    //    //{
    //    //  //ff
    //    //}
    //    //txt.text = hp.ToString();

    //        if (Input.GetAxisRaw("Horizontal") != 0)
    //        {

    //            Move();
    //        }
    //        if (Input.GetKeyDown(KeyCode.Space) && ground == true)
    //        {
    //            Jump();
    //        }
    //        else if (Input.GetKeyDown(KeyCode.C))
    //        {
    //            stab();
    //        }
    //        else if (Input.GetKeyDown(KeyCode.X))
    //        {
    //            slash();
    //        }
    //        else if (Input.GetKeyDown(KeyCode.W))
    //        {
    //            upper();
    //        }
    //        else if (Input.GetKeyDown(KeyCode.S) && ground == false)
    //        {
    //            smash();
    //        }
    //    }

    //void Move()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float moveBy = x * speed;
    //    rb.velocity = new Vector2(moveBy, rb.velocity.y);
    //}

    //public void Jump()
    //{
    //        ground = false;
    //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //}
    //public void Fall()
    //{
    //    ground = false;
    //    rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    //}
    //void stab()
    //{
    //    //c
    //}
    //void slash()
    //{
    //    //x
    //}
    //void smash()
    //{
    //    //s needs to be in the air
    //}
    //void upper()
    //{
    //    //Debug.Log("uppercut");
    //    ////w
    //    //anim.SetTrigger("uppercut");
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "ground")
    //    {
    //        ground = true;
    //    }
    //}











    //private CharacterController controller;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    //private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    //private float gravityValue = -9.81f;

    //private void Start()
    //{
    //    controller = gameObject.AddComponent<CharacterController>();
    //}

    //void Update()
    //{
    //    groundedPlayer = controller.isGrounded;
    //    if (groundedPlayer && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }

    //    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0.1f, Input.GetAxis("Vertical"));
    //    controller.Move(move * Time.deltaTime * playerSpeed);

    //    if (move != Vector3.zero)
    //    {
    //        gameObject.transform.forward = move;
    //    }

    //    // Changes the height position of the player..
    //    if (Input.GetButtonDown("Jump") && groundedPlayer)
    //    {
    //        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    }

    //    playerVelocity.y += gravityValue * Time.deltaTime;
    //    controller.Move(playerVelocity * Time.deltaTime);
    //}
}

