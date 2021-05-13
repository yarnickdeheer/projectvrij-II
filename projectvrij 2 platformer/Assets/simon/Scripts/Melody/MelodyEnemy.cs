using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MelodyEnemy : MonoBehaviour
{
    private MelodyPlayer player;
    public GameObject upArrow;
    public GameObject downArrow;
    private Slider healthbar;
    public float health = 100;
    private bool upOrDown;
    private bool damageTaken;

    private int currentNote;
    private GameObject noteBeingPlayed;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponentInChildren<Slider>();
        player = FindObjectOfType<MelodyPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(noteBeingPlayed == null)
        {
            damageTaken = false;
            currentNote = Random.Range(1, 9);

            spawnNote(currentNote);
        }

        int damage = 0;

        if (upOrDown == player.topOrBottom && !damageTaken)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if ((upOrDown && currentNote == 1) || (!upOrDown && currentNote == 5))
                {
                    damage = 30;
                }
                else
                {
                    damage = 10;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if ((upOrDown && currentNote == 2) || (!upOrDown && currentNote == 6))
                {
                    damage = 30;
                }

                else
                {
                    damage = 10;
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if ((upOrDown && currentNote == 3) || (!upOrDown && currentNote == 7))
                {
                    damage = 30;
                }

                else
                {
                    damage = 10;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if ((upOrDown && currentNote == 4) || (!upOrDown && currentNote == 8))
                {
                    damage = 30;
                }

                else
                {
                    damage = 10;
                }
            }
        }

        if(damage > 0)
        {
            damageTaken = true;
        }
        health -= damage;
        healthbar.value = health / 100;
    }

    void spawnNote(int caseNumber)
    {
        Color arrowColor = Color.white;
        GameObject whichArrow = null;

        if(caseNumber > 4)
        {
            upOrDown = false;
            whichArrow = downArrow;
            caseNumber -= 4;
        }
        else
        {
            upOrDown = true;
            whichArrow = upArrow;
        }

        switch (caseNumber)
        {
            case 1:
                arrowColor = Color.red;
                break;

            case 2:
                arrowColor = Color.green;
                break;
            case 3:
                arrowColor = Color.blue;
                break;
            case 4:
                arrowColor = Color.yellow;
                break;
        }
        noteBeingPlayed = Instantiate(whichArrow, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Quaternion(0, 0, 0, 0), transform);
        noteBeingPlayed.GetComponent<SpriteRenderer>().color = arrowColor;
    }
}
