using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu koja radi da se svakih (javna vrijednost varijable)
//sekundi stvori kocka(prefab) na poziciji (broj stvorene kocke,
//broj stvorene kocke, broj stvorene kocke).

public class Zadatak_5 : MonoBehaviour
{
    public float vremenskiRazmakIzmeduStvaranja;
    public GameObject prefab;
    int brojStvoreneKocke = 0;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(vremenskiRazmakIzmeduStvaranja);
            Instantiate(prefab, new Vector3(brojStvoreneKocke, brojStvoreneKocke, brojStvoreneKocke), Quaternion.identity);
            brojStvoreneKocke++;
        }
    }
}
