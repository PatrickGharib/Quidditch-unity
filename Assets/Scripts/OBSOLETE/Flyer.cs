using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //limit movement speed to  prevent infinite acceleration
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        //move the rider smoothly
        this.transform.position += velocity * Time.fixedDeltaTime;
        //look at the direction of travel
        transform.rotation = Quaternion.LookRotation(velocity);
    }
}
