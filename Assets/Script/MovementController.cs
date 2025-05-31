using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask floor;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform stepPoint;
    [SerializeField] private Transform jumpPoint;
    [SerializeField] private Transform fallPoint;
    [SerializeField] private GameObject stepVFX;
    [SerializeField] private GameObject jumpVFX;
    [SerializeField] private GameObject fallVFX;
    [SerializeField] private AudioClip playerMovementAudioClip;
    [SerializeField] private AudioClip playerJumpAudioClip;
    [SerializeField] private AudioClip playerFallAudioClip;
    private bool wasGrounded = true;
    private float stepTimer;
    public float stepCooldown = 0.3f;
    public static bool isGamePaused = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (GameManagerScript.isGamePaused) return;
        bool isGrounded = IsGrounded();
                
        if (!wasGrounded && isGrounded)
        {
            AudioManager.Instance.PlaySound(playerFallAudioClip);
            GameObject fallEffect = Instantiate(fallVFX, fallPoint.position, fallPoint.rotation);
            Destroy(fallEffect, 0.3f);
        }

        wasGrounded = isGrounded;
        MController();
    }

    private void MController()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * horizontalInput * moveSpeed * Time.deltaTime);

        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f;
        animator.SetBool("isWalk", isMoving);

        if (isMoving)
        {
            stepTimer += Time.deltaTime;
            AudioManager.Instance.PlayLoop(playerMovementAudioClip);

            if (stepTimer >= stepCooldown)
            {
                GameObject stepEffect = Instantiate(stepVFX, stepPoint.position, stepPoint.rotation);
                Destroy(stepEffect, 0.3f);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepCooldown;
            AudioManager.Instance.StopLoop();
        }

        if (horizontalInput > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Jump();
        Gravity();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Jump!");
            AudioManager.Instance.PlaySound(playerJumpAudioClip);
            GameObject jumpEffect = Instantiate(jumpVFX, jumpPoint.position, jumpPoint.rotation);
            Destroy(jumpEffect, 0.3f);
        }
        animator.SetBool("isJump", !IsGrounded());
    }

    private void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundCheck.position, groundCheckRadius, Vector2.down, 0.1f, floor);
        return hit.collider != null;
    }

}
