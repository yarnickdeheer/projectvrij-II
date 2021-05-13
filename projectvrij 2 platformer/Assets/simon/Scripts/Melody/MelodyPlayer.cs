using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MelodyPlayer : MonoBehaviour
{
    public float playerMoveSpeed = 10f;
    private Rigidbody rb;
    public GameObject groundCheckObject;

    public GameObject notePref;

    public Transform currentPitch;

    private List<Transform> currentNotes;
    public List<Transform> topNotes;
    public List<Transform> bottomNotes;

    //trueis top 465, false is bottom 320 
    public bool topOrBottom;
    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentNotes = bottomNotes;
    }
    // Update is called once per frame
    void Update()
    {
        //we gotta move in tandem with the camera view
        Vector3 lastPos = transform.position;

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position = transform.position + (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = transform.position + (Camera.main.transform.right.normalized * Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed);
        }

        Vector3 newPos = transform.position;
        transform.LookAt(transform.position + (newPos - lastPos));

        if (Input.GetKeyDown(KeyCode.Space) && groundCheckObject.GetComponent<groundcheck>().groundTrigger)
        {
            rb.AddForce(Vector3.up * 300);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            topOrBottom = !topOrBottom;
            if (topOrBottom)
                currentNotes = topNotes;
            if (!topOrBottom)
                currentNotes = bottomNotes;
        }

        if (topOrBottom)
        {
            currentPitch.localPosition = Vector3.Lerp(currentPitch.localPosition, new Vector3(currentPitch.localPosition.x, 465, currentPitch.localPosition.z), Time.deltaTime * 10);
        }

        if (!topOrBottom)
        {
            currentPitch.localPosition = Vector3.Lerp(currentPitch.localPosition, new Vector3(currentPitch.localPosition.x, 320, currentPitch.localPosition.z), Time.deltaTime * 10);
        }
        checkNoteInput();
    }

    void checkNoteInput()
    {
        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject temp = Instantiate(notePref, currentNotes[0]);
                temp.GetComponent<Image>().color = Color.red;
                timer = 0.1f;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                GameObject temp = Instantiate(notePref, currentNotes[1]);
                temp.GetComponent<Image>().color = Color.green;
                timer = 0.1f;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                GameObject temp = Instantiate(notePref, currentNotes[2]);
                temp.GetComponent<Image>().color = Color.blue;
                timer = 0.1f;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                GameObject temp = Instantiate(notePref, currentNotes[3]);
                temp.GetComponent<Image>().color = Color.yellow;
                timer = 0.1f;
                return;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
