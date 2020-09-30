using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsBehaviour : MonoBehaviour
{
    public Transform snitch; 
    public float neighborhoodRadius;
    public float force;
    public float ATTRACT = 1;
    public float REPEL = -1; 
    // Update is called once per frame
    void FixedUpdate()
    {
        //return the local neighbourhood of this rider 
        Collider[] localNeighbourhood = Physics.OverlapSphere(transform.position, neighborhoodRadius);

        //go through each rider within vicinity and react accordingly attract to similar objects repel others
        for(int i = 0; i < localNeighbourhood.Length; i++)
        {
            GameObject neighbour = localNeighbourhood[i].gameObject;
            if (neighbour.tag.Equals(tag))
            {
                Behaviour(neighbour, ATTRACT);
            }
            else if (neighbour.tag.Equals("Snitch"))
            {
                continue;
            }
            else
            {
                Behaviour(neighbour, REPEL);
            }
            transform.LookAt(snitch);
        }
    }

    public void Behaviour(GameObject neighbour, float forceType)
    {
        
        Rigidbody rb = neighbour.GetComponent<Rigidbody>();
        Vector3 direction = transform.position - rb.position;
        float distance = direction.magnitude;
        direction = direction.normalized;
        float forceRate = (force / distance);
        var temp = direction * (forceRate / rb.mass) * forceType;
        rb.AddForce(temp);
    }
} 
