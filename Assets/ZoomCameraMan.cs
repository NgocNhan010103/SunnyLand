using UnityEngine;
using System.Collections;

public class SmoothCameraZoom : MonoBehaviour
{
    public float speedCamera = 2f;


    private void Update()
    {
        if (transform.position.x >= -9f &&  transform.position.x < 28.8f)
        {
            movement();
        }
        else if (transform.position.x >= 28.8f)
        {
            transform.position = new Vector3(-9f,transform.position.y, transform.position.z);
        }
    }

    void movement()
    {
        float currentPosition = transform.position.x;
        currentPosition += speedCamera * Time.deltaTime;
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }
}