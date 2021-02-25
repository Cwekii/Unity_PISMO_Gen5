using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; //Prikaz teksta
    [Range(0, 59)]
    public int timeCountMinutes = 5; //Unešena vrijednost u minuta od koliko krecemo npr. imamo 5 minuta za skupiti sve sfere
    [Range(0, 59)]
    public int timeCountSeconds;
    public float allTime;
    public Collect ct;

    private void Start()
    {
        ct = FindObjectOfType<Collect>();
        timeCountMinutes *= 60; //Pretvorili smo minute u sekunda
        allTime = timeCountMinutes + timeCountSeconds;
    }

    private void Update()
    {
        if(allTime >= 0)
        {
            allTime -= Time.deltaTime;

            //Djelimo sa cijelim brojem 60 da dobijemo minute
            int minutes = (int)(allTime / 60);
            //Djelimo sa 60 da dobijemo ostatak kako bismo dobili sekunde
            //int seconds = (int)(timeCount % 60);
            int seconds = Mathf.FloorToInt(allTime % 60);
            
            //Ako je manje od 10 za minute i sekunde
            if(minutes < 10 && seconds < 10)
            {
                timerText.text = "0" + minutes + ":" + "0" + seconds;
            }
            //Ako su minute jednoznamenkaste, a sekunde dvoznamenkaste
            else if(minutes < 10 && seconds >= 10)
            {
                timerText.text = "0" + minutes + ":" + seconds;
            }
            //Minute su dvoznamenkaste, ali sekunde su jednoznamenkaste
            else if(minutes >= 10 && seconds < 10)
            {
                timerText.text = minutes + ":0" + seconds;
            }
            //Minute i sekunde su nam dvoznamenkaste
            else
            {
                timerText.text = minutes + ":" + seconds;
            }
        }
        else
        {
            ct.Lose();
        }
    }
}
