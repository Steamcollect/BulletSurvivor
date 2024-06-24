using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ScoreManager : MonoBehaviour
{
    public float score;

    public TMP_Text scoreText;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore(float scoreGiven)
    {
        score += scoreGiven;
        scoreText.text = score.ToString("F0");
    }
}
