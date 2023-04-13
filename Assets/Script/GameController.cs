using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public float timeSpawn;
    private float spawn;

    private void Start()
    {
        Time.timeScale = 1;
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
            GameObject cube = Instantiate(cubePrefab, new Vector3(Random.Range(20, 20), -5.66f, 0), Quaternion.identity);
            spawn = timeSpawn;
        }
    }
    


}
