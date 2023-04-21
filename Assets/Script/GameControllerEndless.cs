using UnityEngine;


public class GameControllerEndless : MonoBehaviour
{
    GameObject player;
    public GameObject cubePrefab;
    public float timeSpawn;
    private float spawn;

    private void Start()
    {
        Time.timeScale = 1;
        GameObject character = Instantiate(Resources.Load<GameObject>("Prefab/Player"), new Vector3(Random.Range(-13, -13), -5.5f, 0), Quaternion.identity) ;
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
            GameObject cube = Instantiate(cubePrefab, new Vector3(Random.Range(22, 22), -3.75f, 0), Quaternion.identity);
            spawn = timeSpawn;
        }
    }
}
