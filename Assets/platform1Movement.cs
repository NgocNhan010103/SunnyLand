using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class platform1Movement : MonoBehaviour
{

    public float cycleDuration = 15f;
    public float sPeed = 1f;

    public Vector2 StartPos, FinishPos;
    private void Start()
    {

        StartPos = new Vector3(25f, -5f,transform.position.z);
        FinishPos = new Vector3(25f, 2f,transform.position.z);
    }

    private void Update()
    {
        float distance = Mathf.PingPong(Time.time * sPeed / cycleDuration, 1f);
        transform.position = Vector3.Lerp(StartPos,FinishPos,distance);
    }
}
