using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{

    public float neighborhoodRadius;
    public float force;
    private int ATTRACT = 1;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        //return the local neighbourhood of this rider 
        Collider[] localNeighbourhood = Physics.OverlapSphere(transform.position, neighborhoodRadius);

        //go through each rider within vicinity and react accordingly attract to similar objects repel others
        for (int i = 0; i < localNeighbourhood.Length; i++)
        {
            GameObject neighbour = localNeighbourhood[i].gameObject;
            
            Behaviour(neighbour, ATTRACT);
         
        }
    }
    //mak objects chas the snitch 
    public void Behaviour(GameObject neighbour, int forceType)
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
