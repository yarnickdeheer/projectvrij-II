using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCam : MonoBehaviour
{
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 5, -12.5f), 0.3f);
        transform.LookAt(playerTransform);
    }
}
