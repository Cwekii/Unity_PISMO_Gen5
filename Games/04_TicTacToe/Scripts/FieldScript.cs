using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldScript : MonoBehaviour
{
    //OBAVEZNO STAVITI NA SVAKI BUTTON
    public Text btnText;
    Button btn;
    GameManager gm;

    private void Start()
    {
        btn = GetComponent<Button>();
        gm = FindObjectOfType<GameManager>();
        btnText = GetComponentInChildren<Text>();
    }

    public void SetSymbol()
    {
        btnText.text = gm.side;
        btn.interactable = false;
        gm.moves++;
        gm.EndGame();
    }
}
