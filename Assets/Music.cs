using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip audioClip;

    private void Start()
    {
        // Tạo một AudioSource tạm thời
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // Gán AudioClip cho AudioSource
        audioSource.clip = audioClip;

        audioSource.volume = 0.2f;

        // Chạy âm thanh một lần
        audioSource.Play();
    }

    private void Update()
    {
        // Kiểm tra nếu âm thanh đã kết thúc
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            // Chạy lại âm thanh
            audioSource.Play();
        }
    }
}