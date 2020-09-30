using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchMovement : MonoBehaviour
{
    private float XBoundry = 12.5f;
    private float ZBoundry = 22.5f;
    private float YMin = 5;
    private float YMax = 10f;
    public float Acceleration = 3f;
    public float MaxVelocity = 9f;
    private Vector3 CenterSnitch = new Vector3(0, 5, 0);
    private Rigidbody rb;
    private ScoreKeeping sk;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sk = GetComponent<ScoreKeeping>();
    }

    //update every frame
    void Update()
    {
        //clamp velocity and bounds 
        if (rb.velocity.magnitude > MaxVelocity) { rb.velocity = rb.velocity.normalized * MaxVelocity; }
        ClampBounds();
    }
    // physics update
    void FixedUpdate()
    {
        //pick a direction to travel in 
        float x = 0, y = 0, z = 0;

        var specialCoinFlip = Random.Range(0, 100);
        if (specialCoinFlip < 25)
        {
            x = Random.Range(-XBoundry, XBoundry);
            y = Random.Range(YMin, YMax); 
            z = Random.Range(-ZBoundry, ZBoundry);
        }
        rb.AddForce(new Vector3(x , y*0.1f , z ) * Acceleration, ForceMode.Force);

    }
    private void ClampBounds()
    {
        //play area bounds 
        if (transform.position.x < -XBoundry || transform.position.x > XBoundry || transform.position.y < YMin || transform.position.y > YMax
        || transform.position.z > ZBoundry || transform.position.z < -ZBoundry)
        {
            var center = CenterSnitch - transform.position;
            rb.AddForce(center*Acceleration, ForceMode.Impulse);

        }
    }


    //score keeping
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Slytherin"))
        {
            //bool identefier for teams false = slyth
            sk.IncrementScore(false);
           
        }
        else if (collision.gameObject.tag.Equals("Gryffindor"))
        {
            sk.IncrementScore(true);
        }
        //spawn snitch in random location within play area 
        transform.position = new Vector3(Random.Range(-XBoundry, XBoundry), Random.Range(YMin, YMax), Random.Range(-ZBoundry, ZBoundry));
    }

}
