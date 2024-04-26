using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;

    public float volume = 10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("InteractiveObject"))
        {
            AudioListener.volume = volume;

            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}