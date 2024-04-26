using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public bool facingRight = false;
    public LayerMask groundCheck;

    public bool isGrounded = false;
    public bool isFalling = false;
    public bool isJumping = false;

    public float jumpForceX = 6f;
    public float jumpForceY = 4f;

    public float lastPos = 0;

    public float sightRange = 5f; // Khoảng cách tầm nhìn của con ếch
    public Transform target; // Đối tượng nhân vật mà con ếch đuổi theo

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float idleTime = 2f;
    public float currentIdleTime = 0;
    public bool isIdle = true;

    void Start()
    {
        lastPos = transform.position.y;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Mathf.Abs(target.position.x - transform.position.x);
            if (distanceToTarget <= sightRange && isGrounded && !isJumping && !isFalling)
            {
                JumpTowardsTarget();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isIdle)
        {
            currentIdleTime += Time.deltaTime;
            if (currentIdleTime >= idleTime)
            {
                currentIdleTime = 0;
                facingRight = !facingRight;
                spriteRenderer.flipX = facingRight;
                isIdle = false;
                jumping();
            }
        }

        if (IsGrounded() && !isJumping)
        {
            isFalling = false;
            isJumping = false;
            isIdle = true;
        }
        else if (transform.position.y > lastPos && IsGrounded() && !isIdle)
        {
            isJumping = true;
            isFalling = false;
            animator.SetBool("Jumping", true);
        }
        else if (transform.position.y < lastPos && !IsGrounded() && !isIdle)
        {
            isJumping = false;
            isFalling = true;
            animator.SetBool("Jumping", false);
        }

        lastPos = transform.position.y;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), groundCheck);
    }

    private void jumping()
    {
        isJumping = false;
        isIdle = false;
        int direction = 0;
        if (facingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
        animator.SetBool("Jumping", true);
    }

    private void JumpTowardsTarget()
    {
        isIdle = false;
        int direction = target.position.x > transform.position.x ? 1 : -1; // Xác định hướng nhảy dựa trên vị trí của nhân vật
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
        animator.SetBool("Jumping", true);
    }
}