using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    //[SerializeField] TextMesh scoreText;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        
    }

    public void IncreaceScore(int AmountToIncreace)
    {
        score += AmountToIncreace;
        scoreText.text = score.ToString();
        //Debug.Log($"Curent score is {score}.");
    }
}
