using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ienumeratorcic : MonoBehaviour
{
    public Text healthText;
    public float health;
    float maxHealth = 100f;


    private void Start()
    {
        health = maxHealth;
        StartCoroutine(HpUp());
        StartCoroutine(HpDown());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "extraregen")
        {
            health += 5 * Time.deltaTime;
            HealthIspisProvjera();
        }
    }

    IEnumerator HpUp()
    {
        while (true)
        {
            health += 5;
            HealthIspisProvjera();
            yield return new WaitForSeconds(5);
        }
    }
    IEnumerator HpDown()
    {
        while (true)
        {
            health -= 0.05f * health;
            HealthIspisProvjera();
            yield return new WaitForSeconds(10);
        }
    }

    void HealthIspisProvjera()
    {
        if (health > maxHealth) health = maxHealth;
        if (health < 0) health = 0;
        healthText.text = health.ToString();
    }
}