using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Dodjelitit prefabe enemya")]
    public GameObject[] enemies;
    [Header("Dodjeliti prazne game objekte sa scene koji su spawn pointovi")]
    public Transform[] spawnPoints;
    [Header("Početno vrijeme za spawn enemya")]
    [Range(1, 5)]
    public float timer;
    float timerReset;

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //Prvi način - duži
            int randomEnemy = Random.Range(0, enemies.Length);
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
            timer = timerReset;

            //Drugi način - kraći
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            timer = timerReset;
        }
    }
}
