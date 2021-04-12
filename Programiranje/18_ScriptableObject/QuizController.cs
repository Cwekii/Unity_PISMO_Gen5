using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    private QuizQuestion trenutnoPitanje;
    [SerializeField]
    private UIcontroller uIController;
    [SerializeField]
    private QuestionCollection questionCollection;

    [SerializeField]
    private float delayTime = 3f; //Vrijeme nakon što se odgovori da učita novo pitanje

    private void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        //Povuci nepostavljeno pitanje
        trenutnoPitanje = questionCollection.GetUnaskedQuestion();
        //Postavi pitanje i odgovore na UI
        uIController.SetUpUIforQuestion(trenutnoPitanje);
    }

    public void SubmitAnswer(int answerNumber)
    {
        //if(answerNumber == trenutnoPitanje.CorrectAnswer)
        //{
        //  isCorrect = true;
        //}
        bool isCorrect = answerNumber == trenutnoPitanje.CorrectAnswer;

        //UI DA ODRADI ŠTO JE STINUTI ODGOVOR
        uIController.OdradiStisnutiOdgovor(isCorrect);

        //Uzmi sljedeće pitanje
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        ShowQuestion();
    }
}
