using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cetvrtiz : MonoBehaviour
{
    public Text Bijezanje;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kockica")
        {
            StartCoroutine(Bijeg());
        }
    }

    IEnumerator Bijeg()
    {
        yield return new WaitForSeconds(5);
        Bijezanje.text = "nisi uspio pobjeći";
    }
}
