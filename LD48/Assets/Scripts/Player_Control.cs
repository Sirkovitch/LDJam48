using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float maxSpeed = 5;
    public float lerpSpeed = 0.01f;
    public float lerpRot = 0.01f;
    public Animator thisAn;
    public bool camZone = false;


    private float speed = 0;
    private float forwardAxis;
    private float lateralAxis;
    private float forceSpeed = 0;



    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.transform.position = this.transform.position;
    }


    void Update()
    {
        forwardAxis = Input.GetAxis("Forward");
        lateralAxis = Input.GetAxis("Rotation");

        speed = Mathf.Clamp(Mathf.Abs(forwardAxis) + Mathf.Abs(lateralAxis), 0, 1);

        //change lerpSpeed if joystick is moved or not
        if (speed > 0)
        {
            lerpSpeed = 0.03f;
        }
        else
        {
            lerpSpeed = 0.05f;
        }

        forceSpeed = Mathf.Lerp(forceSpeed, speed, lerpSpeed);

        thisAn.SetFloat("Speed", forceSpeed);

        if (speed > .7)
        {
            //slowly rotate when speed is high
            Vector3 lookDirection = new Vector3(lateralAxis, 0, forwardAxis);

            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, lerpRot);
            float visualAngle = transform.eulerAngles.y * Mathf.Deg2Rad;

        }
        
    }
    private void OnTriggerEnter(Collider Collider)
    {
        if(Collider.tag == "CamZone")
        {
            camZone = true;
        }
    }
    private void OnTriggerExit(Collider Collider)
    {
        if (Collider.tag == "CamZone")
        {
            camZone = false;
        }
    }
    void FixedUpdate()
    {

        this.GetComponent<Rigidbody>().velocity = this.transform.forward * forceSpeed * maxSpeed + new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0); ;

    }
}
