using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Flyer))]
public class Cohesion : MonoBehaviour
{
    private Flyer flyer;
    public float radius;
    [SerializeField]
    private Vector3 midpointAverage;
    // Start is called before the first frame update
    void Start()
    {
        flyer = GetComponent<Flyer>();
        Debug.Log(flyer.tag);
        
    }

    
    void FixedUpdate()
    {
        //get local neighbourhood
        Collider[] neighbours = Physics.OverlapSphere(transform.position, radius);
        //percieved local middle position of flyer
        midpointAverage = Vector3.zero;
        int numNeighbours = neighbours.Length;

        foreach(var neighbour in neighbours)
        {
            
            if (neighbour.tag.Equals(tag)){
                var distance = neighbour.transform.position - transform.position;
                midpointAverage += distance;
            }
        }

        //Debug.Log(flyer + ","+ numNeighbours);
        if (numNeighbours > 0)
        {
            midpointAverage = midpointAverage / numNeighbours;
            //Lerp is (a-b)*t where t is interpolant, t is bounded [0,1]
            flyer.velocity += Vector3.Lerp(Vector3.zero, midpointAverage, midpointAverage.magnitude / radius); 
        }
       
    }
}
