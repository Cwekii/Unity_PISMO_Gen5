using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; //broj bodova
    public int life = 3; //Broj života

    private void Update()
    {
        Debug.Log("Score je: " + score + ", a life je: " + life);
        //Na tipku esc ugasi igru

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Izgubio si

        if (life <= 0)
        {
            Debug.Log("Izgubio si");
            Application.Quit();
        }
    }
}
