using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8.) Napišite skriptu koja ima 2 arraya. Jedan sa objektima za stvarati,
//a drugi sa pozicijama za stvoriti (empty game objecti), neka svakih 5 sekundi
//na random poziciji (iz arraya) se stvori random objekt (iz arraya)

public class Zadatak_8 : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnObjekt());
    }

    IEnumerator SpawnObjekt()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
