using UnityEngine;


public class GameControllerEndless : MonoBehaviour
{
    int checkmap;
    public float timeSpawn;
    private float spawn;

    private void Awake()
    {
        checkmap = PlayerPrefs.GetInt("checkmap", 0);
    }
    private void Start()
    {
        CheckMap();
        GameObject character = Instantiate(Resources.Load<GameObject>("Prefab/Player"), new Vector3(Random.Range(-13, -13), -5.5f, 0), Quaternion.identity);
    }

    private void CheckMap()
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
    }

    //trong 2s tao ra 1 obstacle
    public void RandomObstacle()
    {
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            if (checkmap == 1)
            {
                GameObject cube = Instantiate(Resources.Load<GameObject>("Prefab/Obstacle"), new Vector3(Random.Range(22, 22), -3.75f, 0), Quaternion.identity);
            }
            spawn = timeSpawn;
        }
    }
}
