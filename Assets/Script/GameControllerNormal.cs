using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameControllerNormal : MonoBehaviour
{
    int checkmap;
    public float timeSpawn;
    public float timeCoins;
    private float spawnCoins;
    private float spawn;

    private void Awake()
    {
        checkmap = PlayerPrefs.GetInt("checkmap", 0);
    }
    private void Start()
    {
        checkMap();
        GameObject character = Instantiate(Resources.Load<GameObject>("Prefab/Player"), new Vector3(Random.Range(-13, -13), -5.5f, 0), Quaternion.identity);
    }

    private void checkMap()
    {
        if (checkmap == 1)
        {
            GameObject showparallax = Instantiate(Resources.Load<GameObject>("Prefab/ParallaxForest"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 2)
        {
            GameObject showparallax = Instantiate(Resources.Load<GameObject>("Prefab/ParallaxDesert"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 3)
        {
            GameObject showparallax = Instantiate(Resources.Load<GameObject>("Prefab/ParallaxGraveyard"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
        }
        if (checkmap == 4)
        {
            GameObject showparallax = Instantiate(Resources.Load<GameObject>("Prefab/ParallaxSnow"), new Vector3(Random.Range(0, 0), 0, 0), Quaternion.identity);
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
                GameObject cube = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle"), new Vector3(Random.Range(22, 22), -3.75f, 0), Quaternion.identity);
            }
            spawn = timeSpawn;
        }
    }
    public void randomCoins()
    {
        spawnCoins -= Time.deltaTime;
        if (spawnCoins <= 0)
        {
            GameObject coins = Instantiate(Resources.Load<GameObject>("Prefab/Coins"), new Vector3(Random.Range(20, 30), -6f, 0), Quaternion.identity);
            spawnCoins = timeCoins;
        }
    }
}
