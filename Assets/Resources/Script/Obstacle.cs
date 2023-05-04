using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    Uimanager UiEndless;
    UimanagerNormal UiNormal;
    SaveGame saveGame;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UiEndless = Uimanager.FindObjectOfType<Uimanager>();
        UiNormal = UimanagerNormal.FindObjectOfType<UimanagerNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.left * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
            if(SaveGame.checkSaveMap == 1)
            {
                UiEndless.ShowGameOver();
            }
            else
                UiNormal.ShowGameOver();
        }
        else if (collision.gameObject.CompareTag("GameController"))
        {
            UiEndless.ShowScore();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            Destroy(gameObject);
        }
    }
  



}
