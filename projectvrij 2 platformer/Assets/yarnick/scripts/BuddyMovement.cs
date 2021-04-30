using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyMovement : MonoBehaviour
{

    public GameObject playerobj;

    private float dis;
    public float speed;
    public bool follow = true;

    public bool repos = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        
        dis = Vector3.Distance(playerobj.transform.position, this.transform.position);
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        Vector3 np = new Vector3(playerobj.transform.position.x+0.125f, playerobj.transform.position.y, playerobj.transform.position.z + 0.15f);
        if (dis >0.5f)
        {
            repos= true;
        }
        else if ( Input.GetAxisRaw("Vertical") == 0 && repos == true)
        {
            StartCoroutine(delay());
        }
        if (repos == true && follow == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.localPosition, np, step);
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            follow = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            follow = true;
        }
    }
    IEnumerator delay()
    {
        Debug.Log("reset");
        yield return new WaitForSeconds(0.2f);
        repos = false; 
    }
}
