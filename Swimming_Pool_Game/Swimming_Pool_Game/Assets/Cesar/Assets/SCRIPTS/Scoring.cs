using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC : MonoBehaviour
{
    public Text ScoreText;
    public int score = 10;
    public int maxScore;

    public GameObject Score;
    public GameObject BallsText;
    // Start is called before the first frame update
    void Start()
    {
        score = 10;
    }

    public void AddScore (int newScore)
    {
        score -= newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "BALLS: 0" + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if(score == maxScore)
        {
            Score.SetActive(false);
            BallsText.SetActive(true);
        }
    }
}
