using MarchingBytes;
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
    InterstitialAdExample interstitialAdExample;
    AdsInitializer adsInitializer;

    private int removeAds;
    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UiEndless = Uimanager.FindObjectOfType<Uimanager>();
        UiNormal = UimanagerNormal.FindObjectOfType<UimanagerNormal>();
        interstitialAdExample = FindAnyObjectByType<InterstitialAdExample>();
        adsInitializer = FindAnyObjectByType<AdsInitializer>();
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
            adsInitializer.OnInitializationComplete();
            Time.timeScale = 0;
            if(SaveGame.saveMode == 1)
            {
                interstitialAdExample.ShowAd();
                UiEndless.ShowGameOver();
                if (SaveGame.removeAds != 1)
                {
                    interstitialAdExample.ShowAd();
                }
            }
            else
            {
                UiNormal.ShowPopup();
                UiNormal.ShowGameOver();
                if (SaveGame.removeAds != 1)
                {
                    interstitialAdExample.ShowAd();
                }
            }
        }
        else if (collision.gameObject.CompareTag("GameController"))
        {
            UiEndless.ShowScore();
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
        else if (collision.gameObject.CompareTag("DestroyObstacle"))
        {
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
        }
    }
  



}
