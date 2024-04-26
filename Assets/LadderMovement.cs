using UnityEngine;
using UnityEngine.Tilemaps;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 4f;
    private bool isLadder;
    private bool isClimbing;

    public GameObject target;
    [SerializeField] private Rigidbody2D rb;
    private Animator animator;


    private void Start()
    {
        animator = target.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }


    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            animator.SetFloat("IsClimbing", Mathf.Abs(vertical));
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("climb"))
        {
            isLadder = true;
            isClimbing = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("climb"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetFloat("IsClimbing", 0);
        }
    }

}
