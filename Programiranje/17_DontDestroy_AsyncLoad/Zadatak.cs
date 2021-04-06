using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zadatak : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Scena gore
            PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(0);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            //Scena dolje
            PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex - 1);
            SceneManager.LoadScene(0);
        }
    }
}
