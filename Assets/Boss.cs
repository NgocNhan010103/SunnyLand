using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    private Animator animator;
    public GameObject boss;
    public string sortinglayer;

    public float chasing = 25f;
    public float currentPosition = 17.25f;
    public int damage = 0;

    public Vector3 start;
    public Vector3 end;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target.transform.position.x >= 40f && target.transform.position.x <= 46f 
            && target.transform.position.y <= -57f && target.transform.position.y >= -58f)
        {
            animator.SetBool("Run", true);
            Movement();
        }

        if (damage >= 3)
        {
            animator.SetBool("Boom", true);
            Invoke("destroy", 0.5f);
        }
    }

    void Movement()
    {
        transform.position += Vector3.right * 3f * Time.deltaTime;
    }

    void destroy()
    {
        Destroy(boss);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Run", false);
        }

        if (collision.CompareTag("Gai"))
        {
            damage += 1;
        }
    }
}
