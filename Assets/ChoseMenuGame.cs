
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoseMenuGame : MonoBehaviour
{
    public AudioClip click;
    public Canvas menuPause, setting,option  ;
    public Image soundoff, musicoff, sound, music;

    public void Newgame()
    {
        AudioListener.volume = 50f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        menuPause.enabled = false;
        option.enabled = true;
        Scoring.TotalScore = 0;
    }

    public void SettingMenu()
    {
        menuPause.enabled = false;
        setting.enabled = true;
        AudioListener.volume = 50f;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void TurnOffSound()
    {
        sound.enabled = false;
        soundoff.enabled = true;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void TurnOffMusic()
    {
        music.enabled = false;
        musicoff.enabled = true;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void TurnOnSound()
    {
        sound.enabled = true;
        soundoff.enabled = false;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void TurnOnMusic()
    {
        music.enabled = true;
        musicoff.enabled = false;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void Back()
    {
        menuPause.enabled = true;
        option.enabled = false;
        setting.enabled = false;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    void loadingReplay()
    {
        SceneManager.LoadScene(3);
    }

    void loadingMenu()
    {
        SceneManager.LoadScene(0);
    }

    void loadingNewgame()
    {
        SceneManager.LoadScene(1);
    }

    void loadingContinueGame()
    {

    }
    public void Exit()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
        Application.Quit();
    }

    public void loadingMan1()
    {
        AudioListener.volume = 50f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        option.enabled = false;
        Invoke("Man1", 0.1f);
    }
    void Man1()
    {
        SceneManager.LoadScene(1);
    }
}
