using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private 


    // public
    public float speed;
    public Animator animator;
    public BoxCollider2D playerBox;

    // Start is called before the first frame update
    void Start()
    {
       playerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement direction
        float MoveDirection = Input.GetAxisRaw("Horizontal");
        Facing(MoveDirection);

        // movement
        Movement(MoveDirection);

        // jumping
        float JumpDirection = Input.GetAxisRaw("Jump");
        Jump(JumpDirection);


        Crouching();
    }

    void Facing(float MoveDirection)
    {
        animator.SetFloat("movedirection", Mathf.Abs(MoveDirection));

        Vector3 scale = transform.localScale;

        if (MoveDirection < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            animator.SetBool("IsCrouching", false);
        }
        else if (MoveDirection > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("IsCrouching", false);
        }
        transform.localScale = scale;
    }

    void Movement(float MoveDirection)
    {
        Vector3 position = transform.position;
        position.x = position.x + MoveDirection * speed * Time.deltaTime;
        transform.position = position;
    }

    void Jump(float JumpDirection)
    {
        if (JumpDirection > 0)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            playerBox.size = new Vector2(0.8f, 1.4f);
            playerBox.offset = new Vector2(0, 0.6f);
        } else
        {
            playerBox.size = new Vector2(0.6f, 2f);
            playerBox.offset = new Vector2(0f, 1f);
        }
    }
}
