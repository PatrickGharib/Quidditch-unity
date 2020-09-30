using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBludger : MonoBehaviour
{
    public float avoid = 3;
    private Rigidbody rb;
    public Transform Bludger;
    public int DodgeRadius = 10;
    public int Agility = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dist = Bludger.position - transform.position;
        if (dist.magnitude < DodgeRadius)
        {
            if(Random.Range(0,100) < Agility)
            {
                rb.AddForce(-dist/avoid);
                if (rb.velocity.magnitude != 0)
                {
                    transform.rotation = Quaternion.LookRotation(rb.velocity);
                }
            }
        }
    }
}
