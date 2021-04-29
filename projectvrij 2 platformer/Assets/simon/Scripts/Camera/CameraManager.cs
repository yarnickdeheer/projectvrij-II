using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraManager : MonoBehaviour
{
    public CameraStateMachine cameraSM;
    public CameraStill still;
    public CameraShoulder shoulder;
    public CameraOcarina ocarina;
    public Transform playerTransform;
    public GameObject reticle;
    public GameObject musicBulletPrefab;
    public FocusPlayer playerScript;
    public TextMeshPro aboveText;


    // Start is called before the first frame update
    void Start()
    {
        cameraSM = new CameraStateMachine();
        still = new CameraStill(this, cameraSM);
        shoulder = new CameraShoulder(this, cameraSM);
        ocarina = new CameraOcarina(this, cameraSM);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = FindObjectOfType<FocusPlayer>();
        cameraSM.Initialize(still);
    }

    // Update is called once per frame
    void Update()
    {
        cameraSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        cameraSM.CurrentState.PhysicsUpdate();
    }

    public void shootMusic()
    {
        GameObject temp = Instantiate(musicBulletPrefab, (playerTransform.position + playerTransform.forward), new Quaternion(0, 0, 0, 0));
        temp.GetComponent<Rigidbody>().AddForce((playerTransform.forward + transform.forward).normalized * 1000);
        //temp.transform.localScale = new Vector3(size, size, size);
    }
}
