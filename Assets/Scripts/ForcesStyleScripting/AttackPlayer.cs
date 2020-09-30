using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AttackPlayer : MonoBehaviour
{
    private float XBound = 12.5f;
    private float ZBound = 22.5f;
    private float YaxisMin = 5;
    private float YaxisMax = 30f;
    public float Accel = 3f;
    public float MxVelocity = 9f;
    private Vector3 CornerBludger = new Vector3(0, 5, 0);
    private Rigidbody rb;
    public float Radius = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > MxVelocity) { rb.velocity = rb.velocity.normalized * MxVelocity; }
        Clamper();
    }

    private void Clamper()
    {
    //play area bounds 
    if (transform.position.x < -XBound || transform.position.x > XBound || transform.position.y < YaxisMin || transform.position.y > YaxisMax
    || transform.position.z > ZBound || transform.position.z < -ZBound)
        {
        var center = CornerBludger - transform.position;
        rb.AddForce(center * Accel, ForceMode.Impulse);

       }
    }
    void FixedUpdate()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, Radius);
        var dist = Vector3.zero;
        //find first or nearest player and shoot at them quickly
        
            //set the first collider in the list as the closest neighbor
            //if you have to many objects this is a bad solution 
            Vector3 closest = (transform.position - neighbors[0].transform.position); 
            foreach (var neighbor in neighbors)
            {
            if (!neighbor.tag.Equals("Snitch")){
                dist =  neighbor.transform.position - transform.position;
                if (dist.magnitude > closest.magnitude)
                {
                    closest = dist;
                }
            }
            }
        
        
        
        //add force in direction of player
        rb.AddForce(dist * Accel,ForceMode.Impulse);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Slytherin"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<FollowSnitch>().enabled = false;
        }
        else if (collision.gameObject.tag.Equals("Gryffindor"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<FollowSnitch>().enabled = false;
        }
        
        //random respawn for bludger so it  doesn't destroy the entire group of players
        transform.position = new Vector3(Random.Range(-XBound, XBound), Random.Range(YaxisMin, YaxisMax), Random.Range(-ZBound, ZBound));
    }
}

