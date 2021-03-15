using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_1 : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    private void Start()
    {
        score = PlayerPrefs.GetInt("rezultat");
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("rezultat", score);
        }
    }
}
