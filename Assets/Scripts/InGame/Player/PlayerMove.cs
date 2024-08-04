using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;

    private float speed = 7f;
    private float jumpForce = 5f;

    private float moveInput;
    private float flipValue;

    private int countJumpsNow;
    private int countExtraJumps = 1;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = MoveInput();

        countJumpsNow = Ground() ? countExtraJumps : countJumpsNow;

        if (moveInput != 0) flipValue = FlipValue(moveInput);
        transform.eulerAngles = VectorFlip(flipValue);

        Debug.Log(Ground());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (countJumpsNow > 0)
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
            countJumpsNow--;
        }
    }

    private Vector3 VectorFlip(float count)
    {
        Vector3 vector = new Vector3(0, count, 0);
        return vector;
    }

    private float FlipValue(float count)
    {
        return count > 0 ? 180 : 0;
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
