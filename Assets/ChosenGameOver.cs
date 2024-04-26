
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChosenGameOver : MonoBehaviour
{
    public AudioClip answerSound, errorSound,click,A;
    public Canvas questionA,questionB, questionC,questionD, questionE,questionF, questionG, questionH;
    public Canvas passA, passB, passC, passD, passE, passF, passG, passH;
    public Canvas failA,failB,failC,failD,failE,failF,failG,failH;



    public Canvas pause, menuPause, setting, panel, scoring;
    public Image soundoff, musicoff,sound,music;
    public Text score, scoreTotal;

    public float displayTime = 2f;
    public float displayTimelite = 0.5f;
    private float volume = 40f;

    private MethodFunctionQuestionABC methodFunctionQuestionABC;

    private void Start()
    {
        score.text = Scoring.TotalScore.ToString();
        scoreTotal.text = Scoring.TotalScore.ToString();
        methodFunctionQuestionABC = new MethodFunctionQuestionABC();
    }

    
    //Question And Answer;
    //Question A: answer: A;
    
    public void AnswerPassQuesttionA()
    {
        questionA.enabled = false;
        pause.enabled = true;
        panel.enabled = false;
        //answer.enabled = true;
        Invoke("HideCanvasA", displayTime); // Gọi hàm HideCanvas sau thời gian xác định
        Time.timeScale = 1f;
        AudioListener.volume = volume;
        AudioSource.PlayClipAtPoint(answerSound, transform.position);
        Scoring.TotalScore += 1;
        score.text = Scoring.TotalScore.ToString();
        scoreTotal.text = Scoring.TotalScore.ToString();
    }

    public void AnswerFailQuestionA()
    {
        questionA.enabled = false;
        //error.enabled = true;
        Invoke("HideCanvasA", displayTime); // Gọi hàm HideCanvas sau thời gian xác định
        Time.timeScale = 1f;
        AudioListener.volume = volume;
        AudioSource.PlayClipAtPoint(errorSound, transform.position);
        Invoke("QuestionA", displayTimelite);
    }

    void HideCanvasA()
    {
        passA.enabled = false; // Tắt Canvas
        failA.enabled = false;
    }

    void QuestionA()
    {
        questionA.enabled = true;
        Time.timeScale = 0;

    }
    //Question B: answer: B;
    public void AnswerPassQuestionB()
    {
        questionB.enabled = false;
        pause.enabled = true;
        panel.enabled = false;
        //answer.enabled = true;
        Invoke("HideCanvasB", displayTime); // Gọi hàm HideCanvas sau thời gian xác định
        Time.timeScale = 1f;
        AudioListener.volume = volume;
        AudioSource.PlayClipAtPoint(answerSound, transform.position);
        Scoring.TotalScore += 1;
        score.text = Scoring.TotalScore.ToString();
        scoreTotal.text = Scoring.TotalScore.ToString();
    }

    public void AnswerFailQuestionB()
    {
        questionB.enabled = false;
        //error.enabled = true;
        Invoke("HideCanvasB", displayTime); // Gọi hàm HideCanvas sau thời gian xác định
        Time.timeScale = 1f;
        AudioListener.volume = volume;
        AudioSource.PlayClipAtPoint(errorSound, transform.position);
        Invoke("QuestionB", displayTimelite);
    }
    void HideCanvasB()
    {
        passB.enabled = false; // Tắt Canvas
        failB.enabled = false;
    }

    void QuestionB()
    {
        questionB.enabled = true;
        Time.timeScale = 0;

    }
    

    public void Pause()
    {
        Time.timeScale = 0;
        pause.enabled = false;
        menuPause.enabled = true;
        panel.enabled = true;
        scoring.enabled = false;
        Time.timeScale = 1f;
        AudioListener.volume = 50f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0;
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        pause.enabled = true;
        menuPause.enabled = false;
        panel.enabled = false;
        scoring.enabled = true;
        AudioListener.volume = 50f;
        AudioSource.PlayClipAtPoint(click, transform.position);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0;
        Invoke("loadingNewgame", 0.1f);
        Time.timeScale = 1f;
        pause.enabled = true;
        menuPause.enabled = false;
        scoring.enabled = true;
        Scoring.TotalScore = 0;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0;
        Invoke("loadingMenu", 0.1f);
        Time.timeScale = 1f;
        panel.enabled = false;
    }

    public void Setting()
    {
        menuPause.enabled = false;
        setting.enabled = true;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
    }

    public void Back()
    {
        menuPause.enabled = true;
        setting.enabled = false;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
    }

    public void TurnOffSound()
    {
        sound.enabled = false;
        soundoff.enabled = true;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
    }

    public void TurnOffMusic()
    {
        music.enabled = false;
        musicoff.enabled = true;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
    }

    public void TurnOnSound()
    {
        sound.enabled = true;
        soundoff.enabled = false;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
    }

    public void TurnOnMusic()
    {
        music.enabled = true;
        musicoff.enabled = false;
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(click, transform.position);
        Time.timeScale = 0f;
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

    public void soundA()
    {
        AudioListener.volume = 70f;
        AudioSource.PlayClipAtPoint(A, transform.position);
    }

    
}

