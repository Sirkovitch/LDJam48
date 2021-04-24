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


    // Start is called before the first frame update
    void Start()
    {
        thisRb = this.transform.GetComponent<Rigidbody>(); ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float forwardAxis = Input.GetAxis("Forward") * speed;

        thisRb.velocity = speed*this.transform.forward + new Vector3(0, thisRb.velocity.y, 0);

        if(forwardAxis > 0)
        {
            speed = Mathf.Lerp(speed, maxSpeed, acceleration);
        }
        else if (forwardAxis < 0)
        {
            speed = Mathf.Lerp(speed, -maxSpeed, acceleration);
        }
        else
        {
            speed = Mathf.Lerp(speed, 0, 0.1f);

        }

        
    }
    private void Update()
    {
        forwardAxis = Input.GetAxis("Forward");
        rotation = Input.GetAxis("Rotation") * rotateSpeed;
        this.transform.Rotate(0, rotation, 0);
    }
}
