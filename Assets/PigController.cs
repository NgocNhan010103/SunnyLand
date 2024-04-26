using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2d;
    public float direction = 1; // move right;
    public float currentPosition = -48f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {


        if ((currentPosition <= -48f && direction == -1) || (currentPosition >= -39f && direction == 1))
        {
            direction *= -1;
        }

        if (direction == 1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
        else if (direction == -1) 
        {
            transform.localScale =  new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y,transform.localScale.z);        
        }

        currentPosition += Time.deltaTime * direction;
        transform.position = new Vector3(currentPosition,transform.position.y,transform.position.z);

    }

    public void Movement()
    {
    }
}
