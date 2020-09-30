using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidOtherTeam : MonoBehaviour
{
    public float radius;
    public float avoidanceForce;
    public float dodgeBludger;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get all the colliders in surrounding area(sphere)
        Collider[] neighbours = Physics.OverlapSphere(transform.position, radius);
        Vector3 dist = Vector3.zero;
        float bludgerNear = 0f;
        foreach(Collider neighbour in neighbours)
        {
            //find where everyone is around you on your team
            if (neighbour.tag.Equals(gameObject.tag))
            {
                dist += (transform.position - neighbour.transform.position).normalized;
            }

            if (neighbour.tag.Equals("Bludger"))
            {
                if (Random.Range(0, 10) < dodgeBludger)
                {
                    bludgerNear = dodgeBludger;
                }
            }
        }
        dist = dist / neighbours.Length;
        //avoid them, negative avoidance will make you seek out other players instead 
        rb.AddForce(dist * (avoidanceForce + bludgerNear));
    }
}
