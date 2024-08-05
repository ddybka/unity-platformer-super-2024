using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;

    private float speed = 7f;
    private float jumpForce = 8f;

    private float moveInput;
    private float flipValue;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = MoveInput();

        flipValue = (moveInput != 0) ? (moveInput > 0 ? 180 : 0) : flipValue;
        transform.eulerAngles = Vector3.up * flipValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    //
    // Helpers
    //

    private void Jump()
    {
        if (Ground())
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    //
    // Getters
    //

    public float FlipValue()
    {
        return flipValue;
    }

    private Collider2D Ground()
    {
        return Physics2D.OverlapCircle(groundPoint.position, .01f, groundLayer);
    }

    private Vector2 MoveInput()
    {
        return new Vector2(moveInput * speed, rigidbody2D.velocity.y);
    }

}
