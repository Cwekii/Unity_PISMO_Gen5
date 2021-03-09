using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawnPoints;
    public float timer = 5.13f;
    float timerReset;

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timerReset;
            int randomEnemy = Random.Range(0, enemies.Length);
            int randomPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomPoint].transform.position, Quaternion.identity);
            Debug.Log("Stvoren je " + enemies[randomEnemy].name + " na poziciji: " + spawnPoints[randomPoint].transform.position);
        }
    }
}
