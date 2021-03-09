using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnumerator_Ex3 : MonoBehaviour
{
    public Text timeText;
    int timer = 0;

    private void Start()
    {
        StartCoroutine(timerUI());
    }

    IEnumerator timerUI()
    {
        while(true)
        {
            timeText.text = timer.ToString();
            timer++;
            yield return new WaitForSeconds(1);
        }
    }
}
