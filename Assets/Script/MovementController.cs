using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask floor;

    [SerializeField] private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        MController();
    }

    private void MController()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float airSpeed = 0.1f;

        transform.Translate(transform.right * horizontalInput * moveSpeed * Time.deltaTime);

        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f;
        animator.SetBool("isWalk", isMoving);

        if (horizontalInput > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // if (!IsGrounded())
        // {
        //     float clampedX = Mathf.Clamp(body.velocity.x, -airSpeed, airSpeed);
        //     body.velocity = new Vector2(clampedX, body.velocity.y);
        // }

        Jump();
        Gravity();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            Debug.Log("Jump!");
        }
        animator.SetBool("isJump", !IsGrounded());
    }

    private void Gravity()
    {
        if (body.velocity.y < 0)
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, floor);
    }
}
