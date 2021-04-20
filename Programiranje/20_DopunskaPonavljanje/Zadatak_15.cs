using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Napravite scenu i skriptu.
//Kada player uđe u potpunosti unutar forcefielda (Sphera neka fora boje)
//počinjemo pratiti vrijeme playera unutar forcefield objekta u sekundama (Mora biti prikazanu na UI-u).
//Kada player u potpunosti izađe iz forcefielda taj podatak se zabilježava vrijeme
//koje je bio unutar forcefielda u sekundama u PlayerPrefs.

public class Zadatak_15 : MonoBehaviour
{
    public float timer;
    public TMP_Text textic;

    private void Start()
    {
        timer = PlayerPrefs.GetInt("vrijeme");
        textic.text = (int)timer + "";
    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        textic.text = (int)timer + "";
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetInt("vrijeme", (int)timer);
    }
}
