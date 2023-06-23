using MarchingBytes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    UimanagerEndless uimanagerEndless;
    GameControllerEndless gameControllerEndless;
    UimanagerNormal uimanagerNormal;
    InterstitialAdExample interstitialAdExample;

    private int removeAds;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uimanagerEndless = FindObjectOfType<UimanagerEndless>();
        gameControllerEndless = FindAnyObjectByType<GameControllerEndless>();
        uimanagerNormal = FindObjectOfType<UimanagerNormal>();
        interstitialAdExample = FindAnyObjectByType<InterstitialAdExample>();
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
            bool checkBuy = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.RemoveAds);
            if (checkBuy == false)
            {
                interstitialAdExample.ShowAd();
            }
            if(SceneLoader.checkMode)
            {
                uimanagerEndless.ShowBestScore();
                uimanagerEndless.ShowGameOver();
            }
            else if(SceneLoader.checkMode)
            {
                uimanagerNormal.ShowPopup();
                uimanagerNormal.ShowGameOver();
            }
        }
        else if (collision.gameObject.CompareTag("GameController"))
        {
            gameControllerEndless.score++;
            uimanagerEndless.ShowScore();
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
        else if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
    }
}
