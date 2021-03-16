using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Array polja")]
    public Text[] fieldList;
    [Header("Game Over Panel")]
    public GameObject gameOverPanel;
    [Header("Active Game Panel")]
    public Text playerOneName;
    public Text playerTwoName;
    public InputField playerOneNameInput;
    public InputField playerTwoNameInput;
    [Header("Other / X & O")]
    public string side; // Može imati vrijednost X ili O
    public int moves = 0; //Koliko smo napravili poteza

    private void Start()
    {
        gameOverPanel.SetActive(false);
        side = "X";
        moves = 0;
    }

    //Metoda koja mjenja tko je na potezu
    public void ChageSide()
    {
        if(side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }
    }

    //Metoda sa kojom provjeravmo imamo li Pobjednika
    public void EndGame()
    {
        if(fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if(fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if (fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            Debug.Log(side + " wins!");
        }
        else if(moves >= 9)
        {
            Debug.Log("Tie!");
        }
        ChageSide();
    }
}
