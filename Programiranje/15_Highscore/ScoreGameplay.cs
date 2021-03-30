using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameplay : MonoBehaviour
{
    public Text showCurrentScore;
    public int scoreNow;
    public Slider slid;

    private void Start()
    {
        slid.value = scoreNow;
        scoreNow = PlayerPrefs.GetInt("Highscore");
        showCurrentScore.text = scoreNow.ToString();
    }

    public void AddScore()
    {
        scoreNow = (int)slid.value;
        showCurrentScore.text = scoreNow.ToString();
        PlayerPrefs.SetInt("Highscore", scoreNow);
    }
}
