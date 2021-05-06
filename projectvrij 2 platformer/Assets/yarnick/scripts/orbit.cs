using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject s;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(s.transform.position,Vector3.up, (-Input.GetAxisRaw("Horizontal")*2 *Time.deltaTime));
        
    }
}
