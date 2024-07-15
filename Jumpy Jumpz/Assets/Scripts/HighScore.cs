using System;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject ScoreText;

    void Start()
    {
        int score = Int32.Parse(ScoreText.GetComponent<TextMeshProUGUI>().text);
        int highestScore = PlayerPrefs.GetInt("HighScore", score);
        PlayerPrefs.SetInt("HighScore", score);
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highestScore = score;
        } 
        GetComponent<TextMeshProUGUI>().text = "High Score: " + highestScore;
    }
}
