using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeraot_Ex1 : MonoBehaviour
{
    public string outText;

    private void Start()
    {
        Debug.Log("Pozvala se Start metoda");
        StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        //sačekaj 2 sekunde nakon što sam te pozvao da mi 
        //ispišeš debug.log ourText
        yield return new WaitForSeconds(2);
        Debug.Log(outText);
    }
}
