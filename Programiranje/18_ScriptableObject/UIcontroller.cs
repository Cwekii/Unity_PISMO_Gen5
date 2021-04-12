using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Button[] answerButtons;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject correctPanel;
    [SerializeField]
    private GameObject wrongPanel;
    [SerializeField]
    private GameObject gameOverPanel;

    public void SetUpUIforQuestion(QuizQuestion pitanje)
    {
        correctPanel.SetActive(false);
        wrongPanel.SetActive(false);
        questionText.text = pitanje.Question;

        //Posloži ponuđene odgovore
        for (int i = 0; i < pitanje.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = pitanje.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }

        //Započni timer
        StartTimer();
    }

    public void StartTimer()
    {
        CancelInvoke();
        timer = 0;
        timerText.text = timer.ToString();
        InvokeRepeating("TimerLogic", 1f, 1f);
    }

    void TimerLogic()
    {
        timer++;
        timerText.text = timer.ToString();
    }

    public void OdradiStisnutiOdgovor(bool jelTocno)
    {
        //ako je točno
        if(jelTocno)
        {
            correctPanel.SetActive(true);
        }
        //ako nije točno
        else if(!jelTocno)
        {
            wrongPanel.SetActive(true);
        }
    }
}
