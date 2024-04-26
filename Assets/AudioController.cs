using UnityEngine;

public class InteractiveObjectTrigger : MonoBehaviour
{
    public bool checkClip = true;
    public float volume = 30f;
    private Animator animator;

    public Canvas canvas,panel,pause;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && checkClip)
        {
            PlayerController.Destroy(gameObject);
            checkClip = false;
            panel.enabled = true;
            canvas.enabled = true;
            pause.enabled = false;
            animator.SetBool("On", true);
            Time.timeScale = 0;
        }
    }

   
}
