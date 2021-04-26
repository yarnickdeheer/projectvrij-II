using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    public bool groundTrigger = false;
    private void OnTriggerStay(Collider other)
    {
        groundTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        groundTrigger = false;
    }
}
