using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float transparency = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.localPosition = new Vector3(0, transform.localPosition.y + Time.deltaTime, 0);
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, transparency);
        transparency -= Time.deltaTime / 3;

        if(transparency <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
