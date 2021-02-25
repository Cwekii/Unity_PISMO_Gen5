using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public Text scoreText;
    int scoreCurrent;
    int scoreMax;
    GameObject[] objekti;
    public GameObject endGamePanel;
    public Timer tm;
    public Text result;
    public Text endText;

    private void Start()
    {
        tm = FindObjectOfType<Timer>();
        endGamePanel.SetActive(false);
        objekti = GameObject.FindGameObjectsWithTag("Coin");
        scoreMax = objekti.Length;
        scoreText.text = scoreCurrent + "/" + scoreMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            scoreCurrent++;
            Destroy(other.gameObject);
            scoreText.text = scoreCurrent + "/" + scoreMax;
            if (scoreCurrent == scoreMax)
            {
                //ILI  endText.text = (int)(scoreMax * tm.allTime) + ""; 
                result.text = ((int)(scoreMax * tm.allTime)).ToString();
                endText.text = "YOU WIN! YOUR SCORE IS:";
                endGamePanel.SetActive(true);
            }
        }
    }

    public void Lose()
    {
        result.text = ((int)(scoreCurrent * 10)).ToString();
        endText.text = "YOU LOSE! YOUR SCORE IS:";
        endGamePanel.SetActive(true);
    }
}
