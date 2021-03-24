using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnumerator_Survive : MonoBehaviour
{
    public Text woodText;
    public Text foodText;
    public Text goldText;
    public Text populationText;
    public Text stoneText;
    public Text waterText;
    public Text ironText;

    public Text dayText;

    public int wood, food, gold, population, stone, water, iron, days;

    bool gameOver = false;

    private void Start()
    {
        woodText.text = wood + " m";
        foodText.text = food + " kg";
        goldText.text = gold + " €";
        populationText.text = population.ToString();
        stoneText.text = stone + " t";
        waterText.text = water + " L";
        ironText.text = iron + " bars";
        dayText.text = days + ". day";
    }

    //Naše mogućnosti
    //Gumb za otići u rat (dobivamo ili gubimo wood -10% do 25%, gold 0% do 30%, food -5% do 15%, population -13% do 27%, water -15% do -5%, iron -30% do 15%, stone -5% do 5%)
    public void GoToWar()
    {
        if(population >= 100 && gold > 30 && food > population * 1.2f)
        {
            gold -= 30;
            food -= (int)(population * 1.2f);
            wood += (int)Random.Range(wood * -0.1f, wood * 0.25f);
            gold += (int)Random.Range(gold * 0f, gold * 0.3f);
            food += (int)Random.Range(food * -0.05f, food * 0.15f);
            population += (int)Random.Range(population * -0.13f, population * 0.27f);
            water += (int)Random.Range(water * -0.15f, water * -0.05f);
            iron += (int)Random.Range(iron * -0.3f, iron * 0.15f);
            stone += (int)Random.Range(stone * -0.05f, stone * 0.05f);
            NewValues();
        }
    }

    //Metoda za ispis novih vrijednosti
    public void NewValues()
    {
        woodText.text = wood + " m";
        foodText.text = food + " kg";
        goldText.text = gold + " €";
        populationText.text = population.ToString();
        stoneText.text = stone + " t";
        waterText.text = water + " L";
        ironText.text = iron + " bars";
    }
    //Odi u lov
    //Sell wood (10 wood 1 gold)
    //Buy wood ( 5 wood 1 gold)
    //Buy food (5 food za 5 golda)
    //Sell food (10 food za 5 golda)
    //Explore 
    //Pray to Gods

    //Random računalo što može
    //Poplava (gubimo 30% wooda, 5% irona, 15% ljudi, 40% fooda i dobivamo 5% watera)
    //Požar (gubimo 70% wooda, 13% ljudi, 37% fooda, 20% water)
    //Bolest (gubimo 5%-27% ljudi, 10%-30% golda, 15%-22% water, 1%-2% wooda)
    //Revolucija robova (1% - 30% ljudi, 20%-60% irona, 10%-20% water, 10%-40% wood)
    //Vulkan
    //Netko nas je napao (rat)
    //Potres
    //Meteor
    //Baby boom
    //Plodna berba
    //Tehnološki napredak
    //Rudna iskopina

    //Standardno svaki dan
    IEnumerator DayIncrese()
    {
        while(gameOver == false)
        {
            yield return new WaitForSeconds(1);
            days += 1;
            dayText.text = days + ". day";
        }
    }

    //Gubimo hranu na dnevnoj bazi
    IEnumerator FoodLose()
    {
        while(gameOver != true)
        {
            yield return new WaitForSeconds(1);
            food -= (int)Random.Range(population * 0.3f, population);
            foodText.text = food + " kg";
        }
    }

    //Dobivamo hranu od berbe ili domaćeg uzgoja
    IEnumerator FoodGain()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(Random.Range(6, 18));
            food += (int)Random.Range(population * 2.7f, population * 5.5f);
            foodText.text = food + " kg";
        }
    }
}

