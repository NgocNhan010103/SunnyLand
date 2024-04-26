using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScene :  ChosenGameOver
{
    public Canvas Complete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.enabled = true;
            Complete.enabled = true;
            pause.enabled = false;
            scoring.enabled = false;    

        }
    }
}
