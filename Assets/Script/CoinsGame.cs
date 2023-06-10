using MarchingBytes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGame : MonoBehaviour
{
    UimanagerNormal ui;
    Rigidbody2D coins;
    public float moveSpeed;
    SaveGame SaveGame;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindAnyObjectByType<UimanagerNormal>();
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
            SaveGame.SaveCoins(1);
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);

        }
        if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
    }

}
