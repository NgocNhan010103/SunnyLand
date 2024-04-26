
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private Animator batAnim;
    public Transform target;
    public float chasing = 7f;
    public float batSpeed = 0.8f;
    private Vector3 positionbat;

    void Start()
    {
        batAnim = GetComponent<Animator>();

        positionbat = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= chasing || (transform.position != positionbat))
        {
            batAnim.SetTrigger("fly");
            MoveTowards(target.position);
        }
        else
        {
            batAnim.SetTrigger("Nofly");
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        float distance = Vector3.Distance (transform.position, target.position);
        if (distance <= chasing)
        {
            Vector3 directionbat = target.position - transform.position;
            directionbat.Normalize();
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.Translate(directionbat * batSpeed * Time.deltaTime);
            }
            if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.Translate(directionbat * batSpeed * Time.deltaTime);
            }
        }
        else if (distance > chasing)
        {
            Vector3 directionbat = positionbat - transform.position;
            directionbat.Normalize();
            if (positionbat.x > transform.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.Translate(directionbat * batSpeed * Time.deltaTime);
            }
            if (positionbat.x < transform.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.Translate(directionbat * batSpeed * Time.deltaTime);
            }
        }
    }
}
