using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowScore : MonoBehaviour
{
 
    public static Text score;
    //private int gScore;
    // private int sScore;
    private ScoreKeeping sk;
    public GameObject snitch;
    // Start is called before the first frame update
    void Start()
    {
        //score.text = "this is a test";
        score = GetComponent<Text>();
         sk = snitch.GetComponent<ScoreKeeping>();
    }

    // Update when snitch is caught
     void Update()
    {
        score.text = "Gryffindor: " + sk.GryffScore + "  Sytherin: " + sk.SlythScore;
    }
}
