using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager4 : GameManager3
{
    public Text scoreText;
    public Text highScoreText;

    public int score = 0;
    private int highScore = 0;

    private void Start()
    {
        UpdateLife();
        UpdateHighScore();
        StartCoroutine(SpawnCroissant());
    }

    public void UpdateScore()
    {
        scoreText.text = string.Format("SCORE\n{0}", score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highScore);
            UpdateHighScore();
        }
    }

    public void UpdateHighScore()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        highScoreText.text = string.Format("HIGHSCORE\n{0}", highScore);
    }
}