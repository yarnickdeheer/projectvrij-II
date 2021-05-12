using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    Vector3 lastPosition;
    public Transform gg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var direction = transform.position - lastPosition;
        var localDirection = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;
        Debug.Log(localDirection);

        this.transform.position = gg.position;
    }
}
