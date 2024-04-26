using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFollowplatform : MonoBehaviour
{
    public string Ground;

    public Rigidbody2D rb;

    private bool OnMovePlatform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (OnMovePlatform)
        {
            OnMovePlatform = false;
            transform.SetParent(null);
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.SetParent(collision.transform);
            rb.isKinematic = true;
            OnMovePlatform = true;
        }
    }

}
