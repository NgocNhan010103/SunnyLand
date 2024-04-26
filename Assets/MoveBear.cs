using UnityEngine;

public class MoveBear : MonoBehaviour
{
    private Animator bearAnim;
    private Rigidbody2D rbbear;

    public Transform target;
    public float chaseRange = 7f;
    private float MovementSpeed = 3f;
    public float currentPosition = 11f;
    private int direction = 1;


    private void Start()
    {
        bearAnim = GetComponent<Animator>();
        rbbear = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= chaseRange )
            {
                MoveTowards(target.position);
            }
            else
            {
                Normalmove();
            }

    }

    

    private void Normalmove()
    {
        if ((currentPosition >= 19f && direction == 1) || (currentPosition <= 11f && direction == -1))
        {
            direction *= -1;
        }

        if (direction == 1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        currentPosition += Time.deltaTime * direction;

        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        if ((transform.position.x < target.position.x) && (currentPosition >= 11f && currentPosition < 19f))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;

            currentPosition = transform.position.x;
            if (rbbear.IsSleeping())
            {
                bearAnim.SetTrigger("bear");
            }

        }
        
        else if ((transform.position.x > target.position.x) && (currentPosition >= 11f && currentPosition <= 19f))
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;

            currentPosition = transform.position.x;

        }

       
    }
}
