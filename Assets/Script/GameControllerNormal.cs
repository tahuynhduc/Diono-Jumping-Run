﻿using UnityEngine;


public class GameControllerNormal : MonoBehaviour
{
    public GameObject coins;
    public GameObject cubePrefab;
    public float timeSpawn;
    public float timeCoins;
    private float spawnCoins;
    private float spawn;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        RandomObstacle();
        randomCoins();
    }

    //trong 2s tao ra 1 obstacle
    public void RandomObstacle()
    {
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(Random.Range(22, 22), -3.75f, 0), Quaternion.identity);
            spawn = timeSpawn;
        }
    }
    public void randomCoins()
    {
        spawnCoins -= Time.deltaTime;
        if (spawnCoins <= 0)
        {
            GameObject cubs = Instantiate(coins, new Vector3(Random.Range(20, 30), -6f, 0), Quaternion.identity);
            spawnCoins = timeCoins;
        }
    }
}