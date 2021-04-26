using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float lerpSpeed = 0.1f;
    public bool switchMode = true;
    public float offsetY = 10;
    public float offsetZ = -10;
    
    private GameObject player;
    private float rotateSpeed;
    private Vector3 playerPos;
    private Vector3 camPos;
    private Vector3 expectPos;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //rotateSpeed = player.GetComponent<Player_Control>().rotateSpeed;
        offset = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(switchMode == false)
        {
            playerPos = player.transform.position;
            offset = Quaternion.AngleAxis((Input.GetAxis("Rotation")) * rotateSpeed, Vector3.up) * offset;
            expectPos = playerPos + offset;
            camPos = this.transform.position;
            this.transform.position = Vector3.Lerp(camPos, expectPos, lerpSpeed);

            transform.LookAt(player.transform.Find("CamTarget"));
        }
        else
        {
            playerPos = player.transform.position;
            expectPos = playerPos + offset;
            camPos = this.transform.position;
            this.transform.position = Vector3.Lerp(camPos, expectPos, lerpSpeed);

            transform.LookAt(player.transform.position);
        }

    }

}
