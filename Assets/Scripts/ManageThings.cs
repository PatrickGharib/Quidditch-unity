using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIngleton<ManageThings> : MonoBehaviour
{

    

    //create variables for prefabs 
    public GameObject snitch;
    public GameObject riders;
    //public GameObject slyth;
    public List<GameObject> boids = new List<GameObject>();

    //control the number of players spawned for each team 
    public int numRiders;
    //public int numSlyth;

    

    // spawn initial number of players and 1 snitch
    void Start()
    {
        GameObject.Instantiate(snitch, new Vector3(0, 50, 0), Quaternion.identity);
        if (numRiders % 2 != 0)
        {
            numRiders += 1;
        }
        SpawnPlayers(riders, numRiders);
        //SpawnPlayers(slyth, numSlyth);

    }

    // Update is called once per frame

    public void SpawnPlayers(GameObject team, int numPlayers)
    {
        for (int i = 0; i < numPlayers; i++)
        {
            GameObject go = Instantiate(team, new Vector3(i, 50, 0), Quaternion.identity, transform);
            if (i % 2 == 0)
            {
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                go.tag = "Slytherin";
            }
            //instantiate object, then set the parent to the manager object
            boids.Add(go);




        }
    }
}
