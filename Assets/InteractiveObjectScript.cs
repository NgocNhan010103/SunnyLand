using UnityEngine;

public class InteractiveObjectScript : MonoBehaviour
{
    private bool isPlayerTouching = false;
    public GameObject textObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = false;
        }
    }

    private void Update()
    {
        textObject.SetActive(isPlayerTouching);
    }
}
