using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Napišite skriptu koja prikazuje vrijeme u minutama i sekundama,
//vrijeme kreće od 0 sekundi i raste po realnom vremenu te se prikazuje na textu na UI.
//Odradite to sa InvokeRepeating.

public class Zadatak_6 : MonoBehaviour
{
    public int sekunde = 0;
    public int minute = 0;
    public TMP_Text vrijemeText;

    private void Start()
    {
        //vrijemeText.text = minute + ":" + sekunde;
        InvokeRepeating("Vrijeme", 1, 1);
    }

    void Vrijeme()
    {
        sekunde++; //sekunde += 1 //sekunde = sekunde + 1
        if(sekunde > 59)
        {
            minute++;
            sekunde = 0;
        }
        vrijemeText.text = minute + ":" + sekunde;
    }
}
