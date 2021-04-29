using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LooperController : MonoBehaviour
{
    List<KeyCode> moves;

    bool givingInput = false;
    float moveTimer = 0;
    int currentMove;

    public List<GameObject> arrowVisuals;
    public List<Transform> moveList;
    public GameObject tileVisual;

    public GameObject moveVisualParent;
    // Start is called before the first frame update
    void Start()
    {
        moves = new List<KeyCode>();
        for(int i = -10; i < 10; i++)
        {
            for(int j = -10; j < 10; j++)
            {
                Instantiate(tileVisual, new Vector3(i, 0, j), new Quaternion(0,0,0,0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!givingInput)
            {
                moves.Clear();
                moveList.Clear();
                moveTimer = 0;
            }

            if (givingInput)
            {

            }

            givingInput = !givingInput;
        }

        if (givingInput && Input.anyKeyDown)
        {
            //also add visuals
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moves.Add(KeyCode.UpArrow);
                moveList.Add(Instantiate(arrowVisuals[0], moveVisualParent.transform).transform);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moves.Add(KeyCode.DownArrow);
                moveList.Add(Instantiate(arrowVisuals[1], moveVisualParent.transform).transform);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moves.Add(KeyCode.LeftArrow);
                moveList.Add(Instantiate(arrowVisuals[2], moveVisualParent.transform).transform);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moves.Add(KeyCode.RightArrow);
                moveList.Add(Instantiate(arrowVisuals[3], moveVisualParent.transform).transform);
            }

            for(int i = 0; i < moveList.Count; i++)
            {
                moveList[i].localPosition = new Vector3(((moveList.Count - 1) * -50) + (i * 100), 0, 0);
            }
        }

        if(!givingInput)
        {
            moveTimer += Time.deltaTime;

            if (moves.Count > 0)
                moveList[currentMove].GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            if (moveTimer >= 1 && moves.Count > 0)
            {
                KeyCode thisMove = moves[currentMove];

                if (thisMove == KeyCode.UpArrow)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                }

                if(thisMove == KeyCode.DownArrow)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                }

                if (thisMove == KeyCode.LeftArrow)
                {
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                }

                if (thisMove == KeyCode.RightArrow)
                {
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                }

                moveList[currentMove].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                currentMove++;
                moveTimer = 0;

                if (currentMove >= moves.Count)
                {
                    currentMove = 0;
                }
            }
        }
    }
}
