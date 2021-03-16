using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Array polja")]
    public Text[] fieldList; //Textove sa buttona na kojima se prikazuje X ili O
    [Header("Game Over Panel")]
    public GameObject gameOverPanel; //Panel koji se pali kad se odigra igra
    [Header("Active Game Panel")]
    public Text playerOneName; //ime playera jedan na Game panelu
    public Text playerTwoName; //ime playera dva na Game panelu
    public InputField playerOneNameInput; //Unos imena playera jedan na Main Panelu
    public InputField playerTwoNameInput; //Unos imena playera dva na Main Panelu
    public Text scorePlOne; //iznos bodova playera jedan na game panelu
    public Text scorePlTwo; //iznos bodova playera dva na game panelu
    public Text movesText; //Broj poteza
    [Header("Other / X & O")]
    public string side; // Može imati vrijednost X ili O
    public int moves = 1; //Koliko smo napravili poteza

    private void Start()
    {
        gameOverPanel.SetActive(false); //Ugasi game over panel
        side = "X"; //Prvi igrač kreće sa X
        moves = 1; //Prvi potez

        //Očisti textove i omogućni da se može kliknuti na gumbove iz popisa svih polja
        for(int i = 0; i < fieldList.Length; i++)
        {
            fieldList[i].text = ""; //Očisti
            fieldList[i].GetComponentInParent<Button>().interactable = true; //Aktiviraj da se može dirati
        }
        //Postavljamo bodove playeru jedan i dva iz Player Prefsa
        scorePlOne.text = PlayerPrefs.GetInt("ScoreOne").ToString();
        scorePlTwo.text = PlayerPrefs.GetInt("ScoreTwo").ToString();
        //Postavljamo imena playeru jedan i dva iz Player Prefsa
        playerOneName.text = PlayerPrefs.GetString("PlayerOne");
        playerTwoName.text = PlayerPrefs.GetString("PlayerTwo");
        //Prikaz na Game Panelu koji je potez
        movesText.text = "Move " + moves + ".";
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
        //Prikazi da je novi potez
        movesText.text = "Move " + moves + ".";
    }

    //Metoda sa kojom provjeravmo imamo li Pobjednika
    public void EndGame()
    {
        if(fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            CheckWin();
        }
        else if(fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            CheckWin();
        }
        else if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if (fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if(moves > 9)
        {
            CheckWin();
        }
        ChageSide();
    }

    public void ResetGame()
    {
        Start();
    }

    //Nakon što smo ili postavili 3 u nizu ista znaka ili je nerješeno pali game over panel i prikazuje rezultat
    void CheckWin()
    {
        gameOverPanel.SetActive(true); //Upali game over panel
        //Ako je 10 "potez" koji je nemogući, dakle nerješeno je
        if(moves > 9)
        {
            //Uzimamo od childa jer game over panel ima child koji je text
            gameOverPanel.GetComponentInChildren<Text>().text = "TIE!";
        }
        //X pobjedio - Prvi Player
        else if (moves % 2 == 0)
        {
            gameOverPanel.GetComponentInChildren<Text>().text = playerOneName.text + " WINS!";
            //int scoreNew = PlayerPrefs.GetInt("ScoreOne") + 1;
            //PlayerPrefs.SetInt("ScoreOne", scoreNew);
            PlayerPrefs.SetInt("ScoreOne", PlayerPrefs.GetInt("ScoreOne") + 1);
        }
        //O pobjedio - Drugi Player
        else
        {
            gameOverPanel.GetComponentInChildren<Text>().text = playerTwoName.text + " WINS!";
            PlayerPrefs.SetInt("ScoreTwo", PlayerPrefs.GetInt("ScoreTwo") + 1);
        }

    }

    //Poziva se na play gumb kada se unesu imena
    public void SetUpName()
    {
        //Promjeni vrijednost imena isključivo ako su unjeta imena
        if(playerOneNameInput.text != "" && playerTwoNameInput.text != "")
        {
            playerOneName.text = playerOneNameInput.text;
            playerTwoName.text = playerTwoNameInput.text;
            PlayerPrefs.SetString("PlayerOne", playerOneName.text);
            PlayerPrefs.SetString("PlayerTwo", playerTwoName.text);
        }
    }
}
