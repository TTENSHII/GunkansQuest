using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 6.0f;

    private Rigidbody2D rb = null;
    private Vector3 spriteScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteScale = transform.localScale;
    }

    private bool CanJump()
    {
        if (rb.velocity.y == 0)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && CanJump())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        RotateSprite(moveX);
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
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
