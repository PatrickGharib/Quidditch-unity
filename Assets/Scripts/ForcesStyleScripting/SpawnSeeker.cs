using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeeker : MonoBehaviour
{

    public GameObject Seeker;
    public Transform Snitch;
    public GameObject SlytherinSeekerManager;
    public GameObject GryffindorSeekerManager;
    [Range(1, 4)]
    public int NumSeekersTeam = 1;
    // Start is called before the first frame update
    void Start()
    {

        //spawn seekers at their respective sides of the field 
        for (int i = 0; i < NumSeekersTeam * 2; i++)
        {
            GameObject player = Instantiate(Seeker);
            if (i % 2 != 0)
            {
                player.tag = "Slytherin";
                //change color of slytherin seeker to blue (Only change here since prefab is purple)
                Material material = player.GetComponent<Renderer>().material;
                material.color = Color.blue;
                player.transform.parent = SlytherinSeekerManager.transform;
            }
            else
            {
                player.tag = "Gryffindor";
                player.transform.parent = GryffindorSeekerManager.transform;
            }
            //give the seeker information about the snitch 
            player.GetComponent<SeekerFollowSnitch>().Snitch = Snitch;
        }
    }
}
