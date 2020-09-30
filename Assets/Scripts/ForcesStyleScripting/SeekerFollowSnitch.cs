using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SeekerFollowSnitch : MonoBehaviour
{
  
    private Rigidbody rb;
    public Transform Snitch;
    public float ChaseSpeed = 8;
    public float Acceleration = 6;
    private float XBoundry = 12.5f;
    private float ZBoundry = 22.5f;
    private float YMin = 5;
    private float YMax = 10f;
    private Vector3 SideSeeker = new Vector3(3, 8, 2);
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
        //clamp bounds 
        ClampSeeker();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //get direction and magnitude of attractive force to snitch
        var dist =   Snitch.position - transform.position;
        if(dist.magnitude < 4)
        {
            //add force in direction of snitch
            rb.AddForce(dist * (Acceleration * 3), ForceMode.Force);

            //look at snitch
            if (rb.velocity.magnitude != 0)
            {
                transform.rotation = Quaternion.LookRotation(Snitch.position);
            }
        }
        else
        {
            //pick a direction to travel in 
            float x = 0, y = 0, z = 0;

            var specialCoinFlip = Random.Range(0, 100);
            if (specialCoinFlip < 5)
            {
                x = Random.Range(-XBoundry, XBoundry);
                y = Random.Range(YMin, YMax);
                z = Random.Range(-ZBoundry, ZBoundry);
            }
            rb.AddForce(new Vector3(x, y * 0.1f, z) * Acceleration, ForceMode.Force);
           
            //look where Seeker is travelling
            if (rb.velocity.magnitude != 0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
        }
    }

    private void ClampSeeker()
    {
        //play area bounds 
        if (transform.position.x < -XBoundry || transform.position.x > XBoundry || transform.position.y < YMin || transform.position.y > YMax
        || transform.position.z > ZBoundry || transform.position.z < -ZBoundry)
        {
            var center = SideSeeker - transform.position;
            rb.AddForce(center * Acceleration, ForceMode.Impulse);

        }
    }
}
