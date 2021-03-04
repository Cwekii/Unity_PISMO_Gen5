using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public InputField inputField;
    public GameObject panel;
    public Button startGame;
    public Text inGameText;

    private void Start()
    {
        startGame.interactable = false;
    }

    public void EnteredUsername()
    {
        if(inputField.text.Length >= 4)
        {
            startGame.interactable = true;
        }
        else if(inputField.text.Length < 4)
        {
            startGame.interactable = false;
        }
    }

    public void StartGame()
    {
        inGameText.text = inputField.text;
        panel.SetActive(false);
    }
}
