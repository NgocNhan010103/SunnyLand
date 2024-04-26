
using UnityEngine;

public class A : MonoBehaviour
{
    private Animator Anim;
    public Transform target;
    public float chasing = 7f;
    public float Speed = 0.8f;
    private Vector3 position;
    public Rigidbody2D rb;
    public float direc = -1;

    void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= chasing || (transform.position != position))
        {
            MoveTowards(target.position);
        }
        else
        {
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= chasing)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direc *= -1;
                Jumping();
            }
            if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direc *= -1;
                Jumping();
            }
        }
        else if (distance > chasing)
        {
            Vector3 direction = position - transform.position;
            direction.Normalize();
            if (position.x > transform.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direc *= -1;
                Jumping();
            }
            if (position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direc *= -1;
                Jumping();
            }
        }
    }

    void Jumping()
    {
        rb.velocity = new Vector2(7f * direc,6f);
    }
}
