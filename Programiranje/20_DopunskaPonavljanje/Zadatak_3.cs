using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Imajte na sceni 2 audiosourcea, napišite skriptu s kojom na tipku
//"space" palite prvi i gasite drugi ili obrnuto.

public class Zadatak_3 : MonoBehaviour
{
    public AudioSource ass1;
    public AudioSource ass2;

    private void Start()
    {
        ass1.enabled = true;
        ass2.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(ass1.enabled == true)
            {
                ass1.enabled = false;
                ass2.enabled = true;
            }

            else if(ass2.enabled == true)
            {
                ass1.enabled = true;
                ass2.enabled = false;
            }
        }
    }
}
