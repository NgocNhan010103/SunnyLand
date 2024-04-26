using System.Collections;
using UnityEngine;

public class platformMovement2 : MonoBehaviour,IMovable
{
    public float cycleDuration = 15f;
    public float speedplatform = 1f;
    public float waitTime = 1f; // Thời gian chờ ở mỗi điểm (start và end)

    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }

    private void Start()
    {
        StartPosition = new Vector3(121f, -35f, transform.position.z);
        EndPosition = new Vector3(121f, 4f, transform.position.z);
        StartCoroutine(Movement());
    }

    public IEnumerator Movement()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToPosition(StartPosition, EndPosition));
            yield return new WaitForSeconds(waitTime);
            yield return StartCoroutine(MoveToPosition(EndPosition, StartPosition));
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator MoveToPosition(Vector3 StartPosition, Vector3 EndPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < cycleDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / cycleDuration;
            transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            yield return null;
        }
    }
}