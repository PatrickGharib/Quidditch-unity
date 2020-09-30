using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SeekerFollowSnitch))]
[RequireComponent(typeof(Rigidbody))]
public class RespawnSeeker : MonoBehaviour
{
    public int SlytherinTackleProb = 25;
    public int GryffindorTackleProb = 15;
    private void OnCollisionEnter(Collision collision)
    {
        var floorCollision = collision.gameObject.name.Equals("Floor");
        if (floorCollision){
            respawnSeeker();
        }
        //check to see if you tackle other team
        //THIS IS BAD THIS SHOULD CHANGE TO LOOK BETTER 
        if (!collision.gameObject.tag.Equals(tag) && !floorCollision 
            && !(collision.gameObject.tag.Equals("Snitch")) && !(collision.gameObject.name.Equals("Bludger")))
        { 
            //calculate probability of tackling
            if (tag.Equals("Slytherin"))
            { 
                //if tackled turn off snitch following so that inertia is maintained and apply gravity
                if (Random.Range(0, 100) < SlytherinTackleProb)
                {
                    collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    collision.gameObject.GetComponent<SeekerFollowSnitch>().enabled = false;
                }
            }
            if (tag.Equals("Gryffindor"))
            {
                if (Random.Range(0, 100) < GryffindorTackleProb)
                {
                    collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    collision.gameObject.GetComponent<SeekerFollowSnitch>().enabled = false;
                }
            }
        }
    }
    public void ExternalRespawn()
    {
        respawnSeeker();
    }
    private void respawnSeeker()
    {
        //respawn the rider on their side of the field and re-enable snitch following and disable gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        if (tag.Equals("Slytherin"))
        {
            transform.position = new Vector3(0, 1, (float)22.5);
        }
        if (tag.Equals("Gryffindor"))
        {
            transform.position = new Vector3(0, 1, -(float)22.5);
        }
        rb.useGravity = false;
        GetComponent<SeekerFollowSnitch>().enabled = true;
    }
}
