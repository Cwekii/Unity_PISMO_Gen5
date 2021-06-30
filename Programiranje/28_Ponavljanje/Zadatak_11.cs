using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_11 : MonoBehaviour
{
    public float health;
    public float healthRegen;
    public float dmg;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sphera")
        {
            health -= dmg;
        }
        if(other.gameObject.tag == "Heal")
        {
            health -= dmg / 2;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Sphera")
        {
            health -= dmg * Time.deltaTime;
        }

        if(other.gameObject.tag == "Heal")
        {
            health += healthRegen * Time.deltaTime;
        }
    }
}
