using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameControllerNormal : MonoBehaviour
{
    int checkmap;
    public float timeSpawn;
    public float timeCoins;
    private float spawnCoins;
    private float spawn;
    int check;

    private void Awake()
    {
        checkmap = PlayerPrefs.GetInt("checkmap", 0);
        check = PlayerPrefs.GetInt("checkCharacter", 1);
    }
    private void Start()
    {
        checkMap();
        if (check == 1)
        {
            GameObject characterOne = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino01_Sprite"), new Vector3(Random.Range(-13.5f, -13.5f), 7f, 0), Quaternion.identity);
        }
        if (check == 2)
        {
            GameObject characterTwo = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino02_Sprite"), new Vector3(Random.Range(-12.37f, -12.37f), 7f, 0), Quaternion.identity);
        }
        if (check == 3)
        {
            GameObject characterThree = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino03_Sprite"), new Vector3(Random.Range(-12.7f, -12.7f), 7f, 0), Quaternion.identity);
        }
        if (check == 4)
        {
            GameObject characterFor = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino04_Sprite"), new Vector3(Random.Range(-12.74917f, -12.74917f), 7f, 0), Quaternion.identity);
        }
        if (check == 5)
        {
            GameObject characterFive = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino05_Sprite"), new Vector3(Random.Range(-12.55422f, -12.55422f), 7f, 0), Quaternion.identity);
        }
        if (check == 6)
        {
            GameObject characterSix = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino06_Sprite"), new Vector3(Random.Range(-12.35927f, -12.35927f), -7f, 0), Quaternion.identity);
        }
    }

    private void checkMap()
    {
        if (checkmap == 1)
        {
            GameObject ParallaxForest = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 2)
        {
            GameObject ParallaxDesert = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxDesert"), new Vector3(Random.Range(0, 0), -1.1f, 0), Quaternion.identity);
        }
        if (checkmap == 3)
        {
            GameObject ParallaxGraveyard = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxGraveyard"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 4)
        {
            GameObject ParallaxSnow = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxSnow"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
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
            if(checkmap == 1)
            {
                GameObject cube = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle/ObstacleForest"), new Vector3(Random.Range(22, 22), -6.027962f, 0), Quaternion.identity);
            }
            if (checkmap == 2)
            {
                GameObject ObstacleDesert = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle/ObstacleDesert"), new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            }
            if (checkmap == 3)
            {
                GameObject ObstacleCity = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle/ObstacleCity"), new Vector3(Random.Range(22, 22), -6.1f, 0), Quaternion.identity);
            }
            if (checkmap == 4)
            {
                GameObject ObstacleMars = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle/ObstacleMars"), new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            }
            if (checkmap == 5)
            {
                GameObject ObstacleSnow = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle/ObstacleSnow"), new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            }
            spawn = timeSpawn;
        }
    }
    public void randomCoins()
    {
        spawnCoins -= Time.deltaTime;
        if (spawnCoins <= 0)
        {
            GameObject coins = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/Circle"), new Vector3(Random.Range(20, 30), -6f, 0), Quaternion.identity);
            spawnCoins = timeCoins;
        }
    }
}
