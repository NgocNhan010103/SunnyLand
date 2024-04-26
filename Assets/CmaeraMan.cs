using UnityEngine;
using UnityEngine.TextCore.Text;

public class CmaeraMan : MonoBehaviour
{
    private bool followTarget = true;

    public GameObject target,boss; // Tham chiếu đến đối tượng được điều khiển
    public Vector3 targetPosition;

    private Vector3 offset; // Khoảng cách giữa camera và đối tượng

    public float startSize = 6f;  // Kích thước ban đầu của camera
    public float targetSize = 10f;  // Kích thước cuối cùng của camera
    public float zoomDuration = 2f;  // Thời gian để tăng từ 5 lên 10 (giây)

    private float currentSize, currentSize1;  // Kích thước hiện tại của camera
    private float timer, timer1;  // Thời gian đã trôi qua
    private bool isZooming = false;
    private bool followPlayer = true;
    private bool zoom;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        currentSize = startSize;  // Kích thước ban đầu của camera
        timer = 0f;  
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer && !isZooming)
        {
            FollowPlayer();
            iszooming();
        }

        if (isZooming && !followPlayer)
        {
            Zoom();
            zoom = true;
            Movement();
            checkfollow();
        }

        if (!isZooming && followPlayer && zoom)
        {
            Return();
            Zoom1();
            zoom = false;
        }


        
    }

    void FollowPlayer()
    {
        targetPosition = target.transform.position;

        if (followTarget)
        {
            transform.position = target.transform.position + offset;
        }
        else
        {
            transform.position = transform.position;
        }
    }

    void Movement()
    {
        if (transform.position.x >= 35f)
        {
            float currentPosition = transform.position.x;
            currentPosition -= 5f * Time.deltaTime;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        }
    }

    void Return()
    {
        if (transform.position.x > target.transform.position.x)
        {
            float currentPosition = Mathf.PingPong(2f * Time.deltaTime, 1f);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, currentPosition);

        }
    }

    void Zoom()
    {
        timer += Time.deltaTime;
        currentSize = Mathf.Lerp(startSize, targetSize, timer / zoomDuration);
        Camera.main.orthographicSize = currentSize;
    }

    void Zoom1()
    {
        timer1 += Time.deltaTime;
        currentSize1 = Mathf.Lerp(targetSize, startSize, timer1 / zoomDuration);
        Camera.main.orthographicSize = currentSize1;
        Debug.Log("phan ngoc Nhan");
    }

    void checkfollow()
    {
        if (boss == null)
        {
            followPlayer = true;
            isZooming = false;
        }
    }

    void iszooming()
    {
        if (transform.position.x >= 50f && transform.position.x <= 53f && transform.position.y <= -56f && transform.position.y >= -58f)
        {
            isZooming = true;
            followPlayer = false;
        }
    }
}
