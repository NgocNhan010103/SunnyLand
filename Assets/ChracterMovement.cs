using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float currentPosition = -9f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentPosition += Time.deltaTime * 3f;
        transform.position = new Vector3(currentPosition, 0f,0f);
    }
}
