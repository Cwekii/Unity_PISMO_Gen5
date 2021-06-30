using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_13 : MonoBehaviour
{
    public AudioSource prviAs;
    public AudioSource drugiAs;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(prviAs.enabled == true)
            {
                prviAs.enabled = false;
                drugiAs.enabled = true;
                Debug.Log("prvi se gasi");
 
            }
            else if(drugiAs.enabled == true)
            {
                prviAs.enabled = true;
                drugiAs.enabled = false;
                Debug.Log("Prvi se pali");
            }
        }
    }
}
