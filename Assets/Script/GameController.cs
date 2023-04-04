using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public float test;
    private float m_test;
    // Update is called once per frame
    void Update()
    {
        RandomObstacle();



        //Vector2 test = new Vector2(Random.Range(12,14),-3);
        //return;
        //if(cubePrefab)
        //{ 
        //    var position = new Vector2(Random.Range(-10.0f, 10.0f), 0);
        //    Instantiate(cubePrefab, position, Quaternion.identity);
        //}
    }

    private void RandomObstacle()
    {
        m_test -= Time.deltaTime;
        if (m_test < 0)
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(Random.Range(10, 10), -5, 0), Quaternion.identity);
            Debug.Log(m_test);
            m_test = test;
        }
    }
}
