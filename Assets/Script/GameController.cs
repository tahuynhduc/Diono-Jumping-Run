using MarchingBytes;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;


public class GameController : MonoBehaviour
{
    [SerializeField] float timeSpawn;
    private float spawn;
    int createCharacter;
    [SerializeField] List<string> dataObstacle;
    List<GameObject> listObstacle = new List<GameObject>();
    [SerializeField] List<GameObject> dataCharacters;
    [SerializeField] List<GameObject> dataBackgrounds;

    private void Awake()
    {
        Time.timeScale = 1;
        createCharacter = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
        CreateCharacter();
        CreateParallax();
    }
    void Update()
    {
        RandomObstacle();
    }
    private void CreateCharacter()
    {
        GameObject character;
        character = Instantiate(dataCharacters[createCharacter]);
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
        obstacle = EasyObjectPool.instance.GetObjectFromPool(dataObstacle[SceneLoader.selectMap],new Vector3(Random.Range(22, 22), -6.027962f, 0), Quaternion.identity);
        listObstacle.Add(obstacle);
    }
    public void StateGame(int value)
    {
        Time.timeScale = value;
    }
}
