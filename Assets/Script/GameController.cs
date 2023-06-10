using MarchingBytes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class GameController: MonoBehaviour
{
    int checkmap;
    public float timeSpawn;
    private float spawn;
    int check;
    public string obstacleForest;
    public string obstacleDesert;
    public string obstacleCity;
    public string obstacleMars;
    public string obstacleSnow;
    List<GameObject> listObstacle = new List<GameObject>();
    private void Awake()
    {
        checkmap = PlayerPrefs.GetInt("checkmap", 0);
        check = PlayerPrefs.GetInt("checkCharacter", 1);
    }
    private void Start()
    {
        CheckCharacter();
        CreateParallax();
    }
    void Update()
    {
        RandomObstacle();
    }
    private void CheckCharacter()
    {
        GameObject character;
        if (check == 1)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino01_Sprite"), new Vector3(Random.Range(-13.5f, -13.5f), 7f, 0), Quaternion.identity);
        }
        if (check == 2)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino02_Sprite"), new Vector3(Random.Range(-12.37f, -12.37f), 7f, 0), Quaternion.identity);
        }
        if (check == 3)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino03_Sprite"), new Vector3(Random.Range(-12.7f, -12.7f), 7f, 0), Quaternion.identity);
        }
        if (check == 4)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino04_Sprite"), new Vector3(Random.Range(-12.74917f, -12.74917f), 7f, 0), Quaternion.identity);
        }
        if (check == 5)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino05_Sprite"), new Vector3(Random.Range(-12.55422f, -12.55422f), 7f, 0), Quaternion.identity);
        }
        if (check == 6)
        {
            character = Instantiate(Resources.Load<GameObject>("Prefab/Character/Dino06_Sprite"), new Vector3(Random.Range(-12.35927f, -12.35927f), -7f, 0), Quaternion.identity);
        }
    }
    public void RandomObstacle()
    {
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            CreateFromPoolAction();
            spawn = timeSpawn;
        }
    }
    public void CreateParallax()
    {
        GameObject parallax;
        if (checkmap == 1)
        {
            parallax = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 2)
        {
            parallax = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 3)
        {
            parallax = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 4)
        {
            parallax = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 5)
        {
            parallax = Instantiate(Resources.Load<GameObject>("Prefab/Parallax/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
    }
    public void CreateFromPoolAction()
    {
        GameObject obstacle;
        if (checkmap == 1)
        {
            obstacle = EasyObjectPool.instance.GetObjectFromPool(obstacleForest, new Vector3(Random.Range(22, 22), -6.027962f, 0), Quaternion.identity);
            listObstacle.Add(obstacle);
        }
        if (checkmap == 2)
        {
            obstacle = EasyObjectPool.instance.GetObjectFromPool(obstacleDesert, new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            listObstacle.Add(obstacle);

        }
        if (checkmap == 3)
        {
            obstacle = EasyObjectPool.instance.GetObjectFromPool(obstacleCity, new Vector3(Random.Range(22, 22), -6.1f, 0), Quaternion.identity);
            listObstacle.Add(obstacle);

        }
        if (checkmap == 4)
        {
            obstacle = EasyObjectPool.instance.GetObjectFromPool(obstacleMars, new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            listObstacle.Add(obstacle);

        }
        if (checkmap == 5)
        {
            obstacle = EasyObjectPool.instance.GetObjectFromPool(obstacleSnow, new Vector3(Random.Range(22, 22), -6f, 0), Quaternion.identity);
            listObstacle.Add(obstacle);
        }
    }
}
