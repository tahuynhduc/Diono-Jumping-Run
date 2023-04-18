using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGame : MonoBehaviour
{
    static Rigidbody2D coins;
    public float moveSpeed;
    SaveGame SaveGame;
    UimanagerNormal Ui;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<Rigidbody2D>();
        Ui = FindObjectOfType<UimanagerNormal>();
    }

    void Update()
    {
        coins.velocity = Vector3.left * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerNormal"))
        {
            SaveGame.SaveCoins();
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }
    }

}
