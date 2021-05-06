using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float playerMoveSpeed = 10f;
    private Rigidbody rb;
    public GameObject groundCheckObject;

    public List<GameObject> playableLetters;
    public Material green;

    private findEnemies findenemies;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        findenemies = FindObjectOfType<findEnemies>();
    }
    // Update is called once per frame
    void Update()
    {
        /*        transform.LookAt(new Vector3(transform.position.x + Input.GetAxis("Horizontal"),transform.position.y, transform.position.z + Input.GetAxis("Vertical")));

                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                    transform.position = transform.position + transform.forward * Time.deltaTime * playerMoveSpeed;*/


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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playNote(playableLetters[0], 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playNote(playableLetters[1], 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playNote(playableLetters[2], 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playNote(playableLetters[3], 3);
        }
    }

    void playNote(GameObject note, int whichNote)
    {
        Quaternion lookDirection = Quaternion.LookRotation(Camera.main.transform.position);
        Instantiate(note, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), lookDirection, this.transform);

        foreach(GameObject enemy in findenemies.enemiesInRange)
        {
            if (enemy.GetComponent<AttackEnemy>().beaten == false)
            {
                if (whichNote == enemy.GetComponent<AttackEnemy>().melody[enemy.GetComponent<AttackEnemy>().notesChecked])
                {
                    if (enemy.GetComponent<AttackEnemy>().notesChecked == enemy.GetComponent<AttackEnemy>().melody.Count - 1)
                    {
                        enemy.GetComponent<AttackEnemy>().beaten = true;
                        enemy.GetComponent<MeshRenderer>().material = green;
                    }

                    else
                        enemy.GetComponent<AttackEnemy>().notesChecked++;
                }

                else
                {
                    enemy.GetComponent<AttackEnemy>().notesChecked = 0;
                }
            }
        }
    }
}
