using System.Collections;
using UnityEngine;

public class TilemapController : MonoBehaviour,IMovable
{

    public platformMovement2 platformMovement;

    public float cycleDuration = 15f;
    public float speedplatform = 1f;
    public float waitTime = 1f;
   

    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }


    void Start()
    {
        StartPosition = new Vector3(80f, -14f, transform.position.z);
        EndPosition = new Vector3(100f, 4f, transform.position.z);
        StartCoroutine(Movement());
    }


    public IEnumerator Movement()
    {
        yield return StartCoroutine(platformMovement.Movement());
    }

}