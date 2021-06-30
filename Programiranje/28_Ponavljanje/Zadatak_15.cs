using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_15 : MonoBehaviour
{
    public GameObject prefabKocka;

    private void Start()
    {
        InvokeRepeating("StvoriKocku", 0, 10);
    }

    void StvoriKocku()
    {
        Instantiate(prefabKocka, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
