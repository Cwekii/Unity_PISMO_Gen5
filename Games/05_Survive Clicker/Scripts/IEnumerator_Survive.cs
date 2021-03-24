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
    public Text notifications;

    public Text dayText;

    public int wood, food, gold, population, stone, water, iron, days;

    bool gameOver = false;

    private void Start()
    {
        NewValues();
        StartCoroutine(DayIncrese());
        StartCoroutine(FoodLose());
        StartCoroutine(FoodGain());
        StartCoroutine(PopulationGain());
        StartCoroutine(PopulationLose());
    }

    //Naše mogućnosti
    //Gumb za otići u rat (dobivamo ili gubimo wood -10% do 25%, gold 0% do 30%, food -5% do 15%, population -13% do 27%, water -15% do -5%, iron -30% do 15%, stone -5% do 5%)
    public void GoToWar()
    {
        if(population >= 100 && gold > 30 && food > population * 1.2f)
        {
            gold -= 30;
            food -= (int)(population * 1.2f);

            int woodChange = (int)Random.Range(wood * -0.1f, wood * 0.25f);
            wood += woodChange;

            int goldChange = (int)Random.Range(gold * 0f, gold * 0.3f);
            gold += goldChange;

            int foodChange = (int)Random.Range(food * -0.05f, food * 0.15f);
            food += foodChange;

            int populationChange = (int)Random.Range(population * -0.13f, population * 0.27f);
            population += populationChange;

            int waterChange = (int)Random.Range(water * -0.15f, water * -0.05f);
            water += waterChange;

            int ironChange = (int)Random.Range(iron * -0.3f, iron * 0.15f);
            iron += ironChange;

            int stoneChange = (int)Random.Range(stone * -0.05f, stone * 0.05f);
            stone += stoneChange;

            notifications.text += days + ". Day we went to war and result is: " + "\n" + "Population: " + populationChange + "\n" +"Gold: " + goldChange + "\n" + "Food: " + foodChange + "\n" + "Water: " + waterChange + "\n" + "Wood: " + woodChange + "\n" + "Iron: " + ironChange + "\n" + "Stone: " + stoneChange + "\n";
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

    void NewNotificationGain(int data, string jedinica)
    {
        notifications.text += days + ". New " + data + " " + jedinica + "\n";
    }
    void NewNotificationLose(int data, string jedinica)
    {
        notifications.text += days + ". Lost " + data + " " + jedinica + "\n";
    }

    //Odi u lov - gumb
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
            int gainedFood = (int)Random.Range(population * 2.7f, population * 5.5f);
            food += gainedFood;
            foodText.text = food + " kg";
            NewNotificationGain(gainedFood, "kg");
        }
    }

    //Populacija se "razmnožila" hehe sexali su se
    IEnumerator PopulationGain()
    {
        while(gameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(15, 60));
            if (population > 2 && population <= 100)
            {
                int popBoost = (int)Random.Range(1, 5);
                population += popBoost;
                NewNotificationGain(popBoost, "people");
            }
            else if (population > 100)
            {
                int popBoost = (int)Random.Range(population * 0.02f, population * 0.05f);
                population += popBoost;
                NewNotificationGain(popBoost, "people");
            }
            populationText.text = population.ToString();
        }
    }

    //Umru nam stariji i bolesni ljudi
    IEnumerator PopulationLose()
    {
        while(gameOver != true)
        {
            yield return new WaitForSeconds(Random.Range(10, 40));
            int populetionDecrease = (int)Random.Range(population * 0.01f, population * 0.03f);
            population -= populetionDecrease;
            populationText.text = population.ToString();
            NewNotificationLose(populetionDecrease, "people");
        }
    }
}

