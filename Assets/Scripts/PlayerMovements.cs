using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;

    private Rigidbody2D rb = null;
    private bool isJumping = false;
    private Vector3 spriteScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        RotateSprite(moveX);
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
        }
    }

    private void RotateSprite(float moveX)
    {
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-spriteScale.x, spriteScale.y, spriteScale.z);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(spriteScale.x, spriteScale.y, spriteScale.z);
        }
    }
}
