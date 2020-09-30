using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snitchMove : MonoBehaviour
{
    public GameObject snitch;

    public float force;
   
    // Start is called before the first frame update
    void FixedUpdate()
    {
        //return the local neighbourhood of this rider 

        //go through each rider within vicinity and react accordingly attract to similar objects repel others

            force = Random.Range(0, 300);
           
            BoidBehaviour(-1);
            //yield return new WaitForSecondsRealtime(1);
           

        
    }
    //mak objects chas the snitch 
    public void BoidBehaviour( int forceType)
    {

        Rigidbody rb = snitch.GetComponent<Rigidbody>();
        Vector3 direction = transform.position - rb.position;
        float distance = direction.magnitude;
        direction = direction.normalized;
        float forceRate = (force / distance);
        var temp = direction * (forceRate / rb.mass) * forceType;
        rb.AddForce(temp);
    }
}
