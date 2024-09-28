using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBord : MonoBehaviour
{
    public static ScoreBord instance;
    TextMeshProUGUI scoreText;
    public int score = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (PlayerPrefs.HasKey("SCORE"))
        {
            score = PlayerPrefs.GetInt("SCORE");
        }
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }

}
