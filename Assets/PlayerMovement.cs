using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public Collider2D Collider2dCharacter;
    public Canvas canvas, panel;
    public AudioClip Soundjump, soundgam, sounddie;
    private float volume = 20f;
    public string animationname = "fall";
    public Transform groundCheck;
    public LayerMask groundLayer;
    

    public float speed = 5f;
    public float jumpForce = 16f;
    public float sitSpeed = 2f;
    private bool isJumping = false;
    private bool disableJump = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Collider2dCharacter = GetComponent<Collider2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0)   transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0)   transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));


        if (Input.GetKeyDown(KeyCode.W) && !isJumping && IsGrounded() && !disableJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            AudioListener.volume = volume;
            AudioSource.PlayClipAtPoint(Soundjump, transform.position);
            isJumping = true;
        }

        if (IsGroundedTwo())
        {
            isJumping = true;
        }

        if (rb.velocity.y == 0f)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        if (!isJumping && !IsGrounded())
        {
            animator.SetBool("IsFalling", true);
        }


    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }

    public bool IsGroundedTwo()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.1f, 0.02f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bear") || collision.gameObject.CompareTag("bat") 
            || collision.gameObject.CompareTag("spikes") || collision.gameObject.CompareTag("pig") 
            || collision.gameObject.CompareTag("Gai") || collision.gameObject.CompareTag("Boss"))
        {
            animator.SetTrigger("hurt");
            Collider2dCharacter.isTrigger = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            panel.enabled = true;
            canvas.enabled = true; // Hiển thị Canvas
            AudioListener.volume = volume;
            AudioSource.PlayClipAtPoint(sounddie, transform.position);
            Time.timeScale = 0;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gem"))
        {
            AudioListener.volume = volume;
            AudioSource.PlayClipAtPoint(soundgam, transform.position);
        }

        if (collision.gameObject.CompareTag("climb"))
        {
            animator.SetBool("Climb", true);
            disableJump = true;
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("climb"))
        {
            animator.SetBool("Climb", false);
            disableJump = false;
            rb.gravityScale = 5f;
        }
    }

}