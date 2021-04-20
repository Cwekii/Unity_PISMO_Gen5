using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napravite array gameObjecta i neka se svakih 3 sekunde stvori
//jedan game object na random poziciji na sceni po vašem izboru.
//Nakon svakih 10 stvaranja se brzina stvarnja smanji za 10%.
//Ne smije se dogoditi da se objekt stvara brže od 1 sekunde.

public class Zadatak_17 : MonoBehaviour
{
    public GameObject[] prefabs;
    public int countObjects = 0;
    public float timer = 3;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, timer);
    }

    void SpawnObject()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), Random.Range(-7f, 7f)), Quaternion.identity);
        countObjects++;

        if(countObjects % 10 == 0)
        {
            if(timer * 0.9f > 1)
            {
                timer *= 0.9f;
            }
            else if(timer * 0.9f <= 1)
            {
                timer = 1;
            }
        }
        //if(countObjects - 10 == 0)
        //{
        //    //Smanji za 10% 
        //    //Resetiraj countObjects na 0
        //}
    }
}
