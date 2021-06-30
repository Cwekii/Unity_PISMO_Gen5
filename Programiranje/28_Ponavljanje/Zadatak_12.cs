using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_12 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            Debug.Log("Cube je usao u sferu");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Cube je u sferi");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Cube je izasao iz sfere");
        }
    }
}
