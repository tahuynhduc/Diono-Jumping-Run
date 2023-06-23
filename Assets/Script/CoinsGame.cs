using MarchingBytes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGame : MonoBehaviour
{
    Rigidbody2D coins;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        coins.velocity = Vector3.left * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DatabaseManager.CoinsGame(1);
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);

        }
        if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
    }
}
