using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public List<GameObject> playableLetters;
    public List<int> melody;
    private int currentNote;
    private GameObject noteBeingPlayed;
    private GameObject player;

    public int notesChecked;
    public bool beaten = false;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        melody = new List<int>();
        int melodylength = Random.Range(3, 6);

        for(int i = 0; i <= melodylength; i++)
        {
            melody.Add(Random.Range(0, 4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(noteBeingPlayed == null && timer <= 0)
        {
            playNote(playableLetters[melody[currentNote]]);

            if (currentNote < melody.Count - 1)
                currentNote++;

            else
            {
                currentNote = 0;
                timer = 2;
            }
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void playNote(GameObject note)
    {
        Quaternion lookDirection = Quaternion.LookRotation(Camera.main.transform.position);
        noteBeingPlayed = Instantiate(note, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), lookDirection, this.transform);
        //noteBeingPlayed.GetComponent<Rigidbody>().AddForce((new Vector3(player.transform.position.x, player.transform.position.y - 2, player.transform.position.z) - transform.position) * 40);
    }
}
