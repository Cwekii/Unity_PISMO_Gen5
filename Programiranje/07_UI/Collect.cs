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

    private void Start()
    {
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
        }
    }
}
