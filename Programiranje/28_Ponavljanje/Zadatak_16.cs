using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_16 : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Ime", 5, 5);
    }

    void Ime()
    {
        Debug.Log("Ja sam magarac");
    }    
}
