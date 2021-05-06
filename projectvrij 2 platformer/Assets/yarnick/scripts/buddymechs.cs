using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buddymechs : MonoBehaviour
{
    public pcontroller p;
    public Material red;
    public bool dj, sw, s;
    public Color[] colors;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (i == (colors.Length-1))
            {
                i = -1;
            }
            i++;
            gameObject.GetComponent<SpriteRenderer>().color = colors[i];
            Debug.Log(colors.Length + "  :  " + i);

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
           
                i--;
            if (i < 0)
            {
                i = (colors.Length-1);
            }
                gameObject.GetComponent<SpriteRenderer>().color = colors[i];
               
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("A note" + " " + "instrument "  + i);
            //dubblejump
            dj = true;
            s = false;
            sw = false;
            foreach (Transform child in transform)
            {
                child.parent = null;
            }
            p.dubblejump = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("B note" + " " + "instrument " + i);
            sw = true;
            s = false;
            dj = false;
            p.dubblejump = false;
            //shockwave
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("C note" + " " + "instrument " + i);
            s = true;
            sw = false;
            dj = false;
            p.dubblejump = false;
            foreach (Transform child in transform)
            {
                child.parent = null;
            }
            //sleep
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("D note" + " " + "instrument " + i);
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
