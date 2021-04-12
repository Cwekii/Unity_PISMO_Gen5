using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionCollection : MonoBehaviour
{
    //Sva pitanja
    QuizQuestion[] allQuestions;

    private void Awake()
    {
        LoadAllQuestions();
    }

    void LoadAllQuestions()
    {
        allQuestions = Resources.LoadAll<QuizQuestion>("Questions");
    }

    //Povuci ne postavljeno pitanje
    public QuizQuestion GetUnaskedQuestion()
    {
        //AKO SMO SVE ISPUCALI DA ONDA RESETIRAMO PITANJA
        ResetAllQuestionIfAllQuestionsHaveBeenAsked();

        //Učitavanje pitanja koje se postavlja
        //var trenutnoPitanje = allQuestions.Where(pitanjeScritableObjecta => pitanjeScritableObjecta.Asked == false).OrderBy(pitanjeScriptableObjecta => Random.Range(0, int.MaxValue)).FirstOrDefault();
        var trenutnoPitanje = allQuestions.Where(pitanjeScritableObjecta =>
        pitanjeScritableObjecta.Asked == false).OrderBy(pitanjeScriptableObjecta =>
        Random.Range(0, int.MaxValue)).FirstOrDefault();

        trenutnoPitanje.Asked = true;

        return trenutnoPitanje;
    }

    //Provjera jesu li sva pitanja pitana i ako jesu resetiraj
    void ResetAllQuestionIfAllQuestionsHaveBeenAsked()
    {
        if(allQuestions.Any(svakoPitanjePosebno => svakoPitanjePosebno.Asked == false) == false)
        {
            //Foreach
            foreach(QuizQuestion pitanje in allQuestions)
            {
                pitanje.Asked = false;
            }
            //For
            for (int i = 0; i < allQuestions.Length; i++)
            {
                allQuestions[i].Asked = false;
            }
        }
    }
}
