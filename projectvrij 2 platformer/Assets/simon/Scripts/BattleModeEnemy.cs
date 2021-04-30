using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeEnemy : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject lineToPlayer;
    public GameObject musicBullet;

    private bool shootingBullet = false;
    private bool returnBool = false;
    GameObject bullet;
    float playerPerc = 0;
    float shootTimer;

    public ParticleSystem reaction;
    public ParticleSystem getHit;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyLocation = new Vector2(transform.position.x, transform.position.z);
        Vector2 playerLocation = new Vector2(playerTransform.position.x, playerTransform.position.z);
        updateLine(enemyLocation, playerLocation);

        if (!shootingBullet)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootingBullet = true;
                bullet = Instantiate(musicBullet);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            reaction.Play();
        }

        if (shootingBullet)
        {
            //now instead of percentages, it should be a distance, so it travels at the same speed regardless the length of the line
            //0.01 = 1%
            //take the length of the line - which varies each frame
            //if we want to travel a set distance, say 0.1, across this line, we need to get 0.1 relative to the length
            //length/100 * 0.1
            if (!returnBool)
                playerPerc += 0.1f;
            else
                playerPerc -= 0.2f;

            sendMusic(enemyLocation, playerLocation, bullet, playerPerc);

            if (!shootingBullet)
            {
                playerPerc = 0;
                Destroy(bullet);
                shootTimer = Random.Range(1, 4);
            }
        }
    }

    void sendMusic(Vector2 enemyPos, Vector2 playerPos, GameObject shotBullet, float playerPercentage)
    {
        //instantiate a "bullet"

        //send it along the line
        float length = Vector2.Distance(enemyPos, playerPos);
        if (playerPercentage >= length || (playerPercentage <= 0 && returnBool))
        {
            if (playerPercentage >= length)
            {
                //get hit
                getHit.Play();
            }
            shootingBullet = false;
            returnBool = false;
        }
        playerPercentage = (1 / length * playerPercentage);
        //we start at the enemy coordinates, so we move from enemyPos to playerPos
        Vector2 inbetween = (enemyPos * (1 - playerPercentage) + playerPos * playerPercentage);
        //each half is 50%, so if we take that into account with the percentages, we can modify this to travel the line
        Vector3 musicLoc = new Vector3(inbetween.x, 0, inbetween.y);
        shotBullet.transform.position = musicLoc;
        //when it hits the player, let them react, or let them get hit


        if (Vector2.Distance(playerPos, inbetween) < 3 && !returnBool && Input.GetKeyDown(KeyCode.Q))
        {
            //initiate the return protocol
            returnBool = true;
        }

    }

    void updateLine(Vector2 enemyPos, Vector2 playerPos)
    {
        Vector2 linePosition = (enemyPos + playerPos) / 2;
        float length = Vector2.Distance(enemyPos, playerPos);
        float degrees = 0;

        degrees = (enemyPos.x - playerPos.x) / length;

        degrees = Mathf.Asin(degrees);
        degrees = degrees * (180 / Mathf.PI);
        lineToPlayer.transform.position = new Vector3(linePosition.x, 0.1f, linePosition.y);

        if (playerPos.y > enemyPos.y)
        {
            degrees *= -1;
        }
        lineToPlayer.transform.rotation = Quaternion.Euler(0, degrees + 90, 0);

        lineToPlayer.transform.localScale = new Vector3(length, lineToPlayer.transform.localScale.y, lineToPlayer.transform.localScale.z);
    }
}
