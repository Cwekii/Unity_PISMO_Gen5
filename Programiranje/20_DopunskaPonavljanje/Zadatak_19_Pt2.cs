using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Na sceni se save radi na tipku P i sprema se pozicija igrača.

public class Zadatak_19_Pt2 : MonoBehaviour
{
    private void Start()
    {
        transform.position = Zadatak_19_Pt1.positione;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Zadatak_19_Pt1.SavePositions(transform.position);
        }
    }
}
