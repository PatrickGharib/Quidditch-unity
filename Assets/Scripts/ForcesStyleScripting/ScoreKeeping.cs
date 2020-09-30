using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    public int SlythScore { private set; get; } = 0;
    public int GryffScore { private set; get; } = 0;
  
    //team == true then gryffScores, team == false then slythScores
    public  void IncrementScore(bool team)
    {
        //increment score
        if (team) GryffScore++;
        else SlythScore++;
        Debug.Log("Gryffindor: " + GryffScore + ", " + "Slytherin: " + SlythScore);
    }

}
