using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float jump;
    private Animator animate;
    private bool checkJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && checkJump == true)
        {
            rb.velocity = Vector3.up * jump;
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


