using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Napišite skriptu za health koja će utjecati na slider koji pokazuje health.
//Max iznos je 100, a min je 0. Svakih 5 sekundi health se regenerira za 2.5,
//a svaki put kada se stisne tipka "a" neka se skine 10 bodova sa heltha.
//Sve to naravno utječe na slider.

public class Zadatak_9 : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100;
    public float healthRegen = 2.5f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        //Pozvati ienumerator
        StartCoroutine(HealthRegen());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(currentHealth > 0)
            {
                currentHealth -= 10;
                if(currentHealth < 0)
                {
                    currentHealth = 0;
                }
                healthSlider.value = currentHealth;
            }
        }
    }

    IEnumerator HealthRegen()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            if(currentHealth < maxHealth && currentHealth > 0)
            {
                currentHealth += healthRegen;
                if (currentHealth > 100)
                {
                    currentHealth = 100;
                }
                healthSlider.value = currentHealth;
            }
        }
    }
}
