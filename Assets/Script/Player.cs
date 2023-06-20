using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    SettingMusic music;
    Rigidbody2D rb;
    public float jump;
    private Animator animate;
    private bool checkJump;
    bool soundGame;
    void Start()
    {
        soundGame = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.soundGame);
        music = FindAnyObjectByType<SettingMusic>();
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.anyKeyDown && checkJump == true)
        {
            rb.velocity = Vector3.up * jump;
            if(soundGame)
            {
                music.OnSound();
            }
            else 
            {
                music.OffSound();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            checkJump = true;
            animate.SetTrigger("Run");
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            checkJump = false;

            if (checkJump != true)
            {
                animate.SetTrigger("Jump");
            }
        }
    }
}


