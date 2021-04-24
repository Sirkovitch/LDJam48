using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float maxSpeed = 5;
    public float acceleration = 0.1f;
    public float rotateSpeed = 2;
    
    private Rigidbody thisRb;
    private float speed = 0;
    private float forwardAxis;
    private float rotation;
    public Animator thisAn;


    // Start is called before the first frame update
    void Start()
    {
        thisRb = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisRb.velocity = speed*this.transform.forward + new Vector3(0, thisRb.velocity.y, 0);

        if(forwardAxis > 0)
        {
            speed = Mathf.Lerp(speed, maxSpeed, acceleration);
        }
        else if (forwardAxis < 0)
        {
            speed = Mathf.Lerp(speed, -maxSpeed/2, acceleration);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0, 0.1f);

        }
        thisAn.SetFloat("Speed", speed/maxSpeed);
        
    }
    private void Update()
    {
        forwardAxis = Input.GetAxis("Forward");
        rotation = Input.GetAxis("Rotation") * rotateSpeed;
        this.transform.Rotate(0, rotation, 0);

    }
}
