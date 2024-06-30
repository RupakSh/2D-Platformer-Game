using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [SerializeField] private Rigidbody2D rb2d;   
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D playerBox;    

    private bool isGrounded;

    // Start is called before the first frame update
    
    void Start()
    {
        // not really necessary but good habbit
        playerBox = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // getting the vector for movement direction
        float MoveDirection = Input.GetAxisRaw("Horizontal");
        
        // the player obeys the above vector
        Facing(MoveDirection);

        // movement of the player
        Movement(MoveDirection);

        // jumping
        float jumpDirection = Input.GetAxisRaw("Vertical");
        Jump(jumpDirection);

        // crouching
        Crouching();
    }

    void Facing(float MoveDirection)
    {
        // playing animation
        animator.SetFloat("movedirection", Mathf.Abs(MoveDirection));

        // Making the player face both the directions
        Vector3 scale = transform.localScale;

        if (MoveDirection < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            animator.SetBool("iscrouching", false);
        }
        else if (MoveDirection > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("iscrouching", false);
        }

        transform.localScale = scale;
    }

    void Movement(float MoveDirection)
    {
        // Multiplying direction vector with speed for player movement
        Vector3 newPosition = transform.position;
        newPosition.x = newPosition.x + MoveDirection * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    void Jump(float jumpDirection)
    {
        animator.SetFloat("jump", jumpDirection);

        if (jumpDirection > 0 && isGrounded)
        {
            animator.SetTrigger("okjump");
            rb2d.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            print("Yes the player is grounded");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            print("No the player is not grounded");
            isGrounded = false;
        }
    }
    void Crouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("iscrouching", true);
            playerBox.size = new Vector2(0.8f, 1.4f);
            playerBox.offset = new Vector2(0, 0.6f);
        }
        else
        {
            
            playerBox.size = new Vector2(0.6f, 2f);
            playerBox.offset = new Vector2(0f, 1f);
        }
    }
}
