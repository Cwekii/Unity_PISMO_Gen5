using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Napravite skriptu koja učitava 3 fonta u array. Na pritisku lijeve tipke miša neka se promjeni
font za jedan na veću u arrayu, a na pritisku desne tipke neka se promjeni font za jedan nižu u
arrayu. Svaka promjena fonta je vidljiva na tekstu na sceni. Također mora biti i jedan text
mesh pro na sceni koji će samo brojati koliko puta je napravljena promjena fonta.
*/

public class Zadatak_10 : MonoBehaviour
{
    public TMP_Text promjenaText;
    public Text testniText;

    private int brojac = 0;
    private int currentFontNumber = 0;
    public Font[] fonts;

    private void Start()
    {
        promjenaText.text = brojac.ToString();
        testniText.font = fonts[currentFontNumber];
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(currentFontNumber < fonts.Length - 1)
            {
                currentFontNumber++;
            }
            else
            {
                currentFontNumber = 0;
            }
            testniText.font = fonts[currentFontNumber];
            brojac++;
            promjenaText.text = brojac.ToString();
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(currentFontNumber == 0)
            {
                currentFontNumber = fonts.Length - 1;
            }
            else
            {
                currentFontNumber--;
            }
            testniText.font = fonts[currentFontNumber];
            brojac++;
            promjenaText.text = brojac.ToString();
        }
    }
}
