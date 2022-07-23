using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;

    public void IncreaceScore(int AmountToIncreace)
    {
        score += AmountToIncreace;
        Debug.Log($"Curent score is {score}.");
    }
}
