
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public string sortinglayer;
    private Renderer renderergem;
    public GameObject gem;
    void Start()
    {
        renderergem = GetComponent<Renderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            renderergem.sortingLayerName = sortinglayer;
            Destroy(gem);
        }
    }
}
