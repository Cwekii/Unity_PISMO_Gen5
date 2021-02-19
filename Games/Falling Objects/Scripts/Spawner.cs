using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; //predmet koji se stvara
    public float timer = 3; //vremenski period za spawnanje objekata
    float timerReset; //vraćanje timera na početak
    int spawnCount; //broj koliko smo prefaba stvorili

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float randomPozicijaX = Random.Range(-4f, 4f);
            Instantiate(prefab, new Vector3(randomPozicijaX, 15, 0), Quaternion.identity);
            timer = timerReset;
            //Svakih 13 stvorenih mi ubrzamo vrijeme stvaranja za 10%

            if (spawnCount == 13 && timerReset > 0.7f)
            {
                timerReset *= 0.9f;
                spawnCount = 0;
            }
        }
    }
}
