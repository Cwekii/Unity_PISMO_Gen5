using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu gdje se bool "Umro" aktivira kada objekt dotakne drugi objekt.
//Napravite i drugu varijantu gdje se bool "Umro" aktivira kada objekt izađe kroz drugi objekt.

public class Zadatak_14 : MonoBehaviour
{
    public bool umro = false;

    private void OnCollisionEnter(Collision collision)
    {
        umro = true;
    }

    private void OnTriggerExit(Collider other)
    {
        umro = true;
    }
}
