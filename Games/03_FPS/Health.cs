using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slideHeatlh;
    public Text textHealth;

    public float maxHealth;
    public float currentHealth;

    public float healthRegen;

    private void Start()
    {
        currentHealth = maxHealth;
        textHealth.text = currentHealth + "/" + maxHealth;
        slideHeatlh.maxValue = maxHealth;
        slideHeatlh.value = currentHealth;
    }

    private void Update()
    {
        if(currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += healthRegen * Time.deltaTime;
        }

        if(currentHealth <= 0)
        {
            //YOU DIED MADFAKA
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth -= 10;
        }
        textHealth.text = (int)currentHealth + "/" + (int)maxHealth;
        slideHeatlh.value = currentHealth;
    }
}
