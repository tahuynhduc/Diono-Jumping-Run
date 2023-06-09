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
    private int checkSound;
    void Start()
    {
        checkSound = PlayerPrefs.GetInt("checkMusic",0);
        music = FindAnyObjectByType<SettingMusic>();
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.anyKeyDown && checkJump == true)
        {
            rb.velocity = Vector3.up * jump;
            if(checkSound == 2)
            {
                music.OnSound();
            }
            if(checkSound == 1) 
            {
                music.OffSound();
            }
            Debug.Log("Test");
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


