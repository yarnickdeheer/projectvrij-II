using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buddymechs : MonoBehaviour
{
    public player p;
    public Material red;
    public bool dj, sw, s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //dubblejump
            dj = true;
            s = false;
            sw = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            p.dubblejump = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sw = true;
            s = false;
            dj = false;
            p.dubblejump = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            //shockwave
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            s = true;
            sw = false;
            dj = false;
            p.dubblejump = false;

            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //sleep
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "waveable" && sw==true)
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up *20);
            other.transform.parent = transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "waveable" && sw == true)
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * 20);
            other.transform.parent = transform;
        }
        else if (other.gameObject.tag == "waveable" && s == true)
        {
            other.GetComponent<MeshRenderer>().material = red ;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "waveable" && sw == true)
        {
            other.transform.parent = null;
        }
        else if (other.gameObject.tag == "waveable" && s == true)
        {
            other.GetComponent<MeshRenderer>().material = default;
        }
    }
}
