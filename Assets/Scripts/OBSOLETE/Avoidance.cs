using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Flyer))]
public class Avoidance : MonoBehaviour
{
    private Flyer wizard;
    public float radius;
    public float repulsion;
    [SerializeField]
    private Vector3 average;

    // Start is called before the first frame update
    void Start()
    {
        wizard = GetComponent<Flyer>();
    }

    // Update is called once per frame
    void Update()
    {
        //look around to see neighbours
        Collider[] neighbors = Physics.OverlapSphere(transform.position, radius);
         average = Vector3.zero;
        int players = neighbors.Length;

        //find where to go to avoid neighbours  
        foreach (var neighbor in neighbors)
        {
           if (!neighbor.tag.Equals(this.tag))
           {
           
                average -=  (transform.position - neighbor.transform.position) ;
              
           }
            
        }
        average = average / players;
        //apply avoidance force to this boid
        wizard.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude /radius) * repulsion ;
    }
}
