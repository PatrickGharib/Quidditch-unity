using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobobo : MonoBehaviour
{
    public Vector3 accerleration;
    public Vector3 velocity;
    private int maxVel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate() 
    {   if(velocity.magnitude > maxVel)
        {
            velocity = velocity.normalized * maxVel;

        }
        transform.position += velocity * Time.fixedDeltaTime;
        // velocity += accerleration;
        transform.rotation = Quaternion.LookRotation(velocity);

    }
  
}
