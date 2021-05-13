using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    private Vector3 movementDirection;
    //private bool playerIsOnTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput(movementDirection);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movementDirection * Time.deltaTime * 20);
        //if (playerIsOnTop)
        //{
        //    GameObject.FindGameObjectWithTag("Player").transform.position += movementDirection * Time.deltaTime * 10;
        //}
    }

    void CheckInput(Vector3 currentDirection)
    {
        Vector3 newDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            newDirection = new Vector3(0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            newDirection = new Vector3(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            newDirection = new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            newDirection = new Vector3(-1, 0, 0);
        }

        if(newDirection == currentDirection)
        {
            movementDirection = Vector3.zero;
        }
        else if(newDirection != Vector3.zero)
        {
            movementDirection = newDirection;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
    //    {
    //        playerIsOnTop = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        playerIsOnTop = false;
    //    }
    //}
}
