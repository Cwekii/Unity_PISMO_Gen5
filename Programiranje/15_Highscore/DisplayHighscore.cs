using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public Text[] highscoreTexts; //Prikazje u svakom tekstu po jedna rezultat
    public Text myHighscore; //Prikaz mog highscora
    public int refreshRate = 30; //Vrijeme ponovog zahtjeva za highscorom
    Highscore highscoreManager;

    //Ako je na istoj sceni!
    public void OnButtonClickUpdate()
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i + 1 + ". Loading...";
        }

        highscoreManager = GetComponent<Highscore>();

        //Započni refresh rate
        StartCoroutine(refreshScores());
    }

    public void ShowOnTextWhenHighscoresDownloaded(Highscore.highscore[] highscroeList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            //Stvori redni broj
            highscoreTexts[i].text = i + 1 + ". ";
            if(highscroeList.Length > 1)
            {
                if(i > highscroeList.Length)
                {
                    highscoreTexts[i].text = "Data does not exist";
                }
                else if(i < highscroeList.Length)
                {
                    //Dodaj tekst username i razmak sa scoreom i znakom vrijednosti za bodove (moze biti $, kg, m, bodova, a ne mora biti ništa)
                    highscoreTexts[i].text += highscroeList[i].username + " - " + highscroeList[i].score + " m";
                }
            }
        }
        //Vaš score zasebno u igri iako ne mora biti, ali i može biti u top listi 
        myHighscore.text = highscoreManager.userNick + " - " + PlayerPrefs.GetInt("Highscore");
    }

    IEnumerator refreshScores()
    {
        while(true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
