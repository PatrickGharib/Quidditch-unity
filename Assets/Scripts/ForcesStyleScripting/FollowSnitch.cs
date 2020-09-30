using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FollowSnitch : MonoBehaviour
{
  
    private Rigidbody rb;
    public Transform Snitch;
    public float ChaseSpeed = 5;
    public float Acceleration = 3;
    //private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    { 
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //clamp the velocity of each flyer, did this here because of weird ordering of physics execution in fixedupdate 
        if (rb.velocity.magnitude > ChaseSpeed) { rb.velocity = rb.velocity.normalized * ChaseSpeed; }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //get direction and magnitude of attractive force to snitch
        var dist =   Snitch.position - transform.position;
        //add force in direction of snitch
        rb.AddForce(dist * Acceleration);
        //look at snitch
        if (rb.velocity.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}
