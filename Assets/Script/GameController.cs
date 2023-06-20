using MarchingBytes;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;


public class GameController : MonoBehaviour
{
    public float timeSpawn;
    private float spawn;
    // public string obstacleForest;
    // public string obstacleDesert;
    // public string obstacleCity;
    // public string obstacleMars;
    // public string obstacleSnow;
    int checkMap;
    int check;
    [SerializeField] List<string> dataObstacle;
    List<GameObject> listObstacle = new List<GameObject>();
    [SerializeField] List<GameObject> dataCharacters;
    [SerializeField] List<GameObject> dataBackgrounds;

    private void Start()
    {
        checkMap = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.SaveMap);
        check = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
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
        character = Instantiate(dataCharacters[check]);
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
        parallax = Instantiate(dataBackgrounds[0]);
        //parallax is not complete because just made a parallax
    }
    public void CreateFromPoolAction()
    {
        GameObject obstacle;
        obstacle = EasyObjectPool.instance.GetObjectFromPool(dataObstacle[checkMap],new Vector3(Random.Range(22, 22), -6.027962f, 0), Quaternion.identity);
        listObstacle.Add(obstacle);
    }
}
