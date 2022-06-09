using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager4 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissant;

    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    public int life = 2;
    public int score = 0;
    private int highScore = 0;

    private void Start()
    {
        UpdateLife();
        UpdateHighScore();
        StartCoroutine(SpawnCroissant());
    }

    IEnumerator SpawnCroissant()
    {
        while (true)
        {
            float randomX = Random.Range(-6f, 6f);
            int count = 0;
            while (count < 5)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 15f), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                count++;
            }

            float delay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(delay);
        }
    }

    public void UpdateLife()
    {
        lifeText.text = string.Format("x {0}", life);
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