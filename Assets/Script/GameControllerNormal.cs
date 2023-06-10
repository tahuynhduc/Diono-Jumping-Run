using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;
using UnityEngine.SocialPlatforms;

public class GameControllerNormal : GameController
{
    public float timeCoins;
    private float spawnCoins;
    public string coin;
    List<GameObject> listCoins = new List<GameObject>();
    private void Update()
    {
        randomCoins();
        RandomObstacle();
    }
    public void randomCoins()
    {
        spawnCoins -= Time.deltaTime;
        if (spawnCoins <= 0)
        {
            CreateCoins();
            spawnCoins = timeCoins;
        }
    }

    private void CreateCoins()
    {
        GameObject coins = EasyObjectPool.instance.GetObjectFromPool(coin, new Vector3(Random.Range(20, 30), -6f, 0), Quaternion.identity);
        listCoins.Add(coins);
    }
}
