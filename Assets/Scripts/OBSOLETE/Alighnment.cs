using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Flyer))]
public class Alighnment : MonoBehaviour
{
    private Flyer wizard;
    public float radius;

    [SerializeField]
    private Vector3 perceviedVelocity;

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
        perceviedVelocity = Vector3.zero;
        int players = neighbors.Length;
        foreach (var neighbor in neighbors)
        {
            if (neighbor.tag.Equals(this.tag))
            {
                perceviedVelocity += wizard.velocity; 
            }

        }
        perceviedVelocity = perceviedVelocity/ players;

        // ;
        wizard.velocity = (perceviedVelocity - wizard.velocity)/Vector3.Lerp(Vector3.zero, perceviedVelocity, perceviedVelocity.magnitude / radius).magnitude; 
    }
}

