using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu koja ima javnu varijablu "Health".
//Kada cube stoji u sferi neka gubi health za "5 * Time.deltaTime"

public class Zadatak_4 : MonoBehaviour
{
    public float health = 100;

    private void OnTriggerStay(Collider other)
    {
        if(health > 0)
        {
            health -= 5 * Time.deltaTime;
        }
        else if(health < 0)
        {
            health = 0;
        }
    }
}
