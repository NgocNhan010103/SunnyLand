using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;

    private float chasing = 7f;
    public float distance;
    public Vector3 Pos1, Pos2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Pos1 = transform.position;
        Pos2 = target.position;
        distance = Mathf.Abs(target.position.y - transform.position.y);
        if ((distance <= chasing) && (target.position.x >= transform.position.x - 0.7f && target.position.x <= transform.position.x + 0.3f)) 
        {
            rb.gravityScale = 2f;
        }
    }

    
}
