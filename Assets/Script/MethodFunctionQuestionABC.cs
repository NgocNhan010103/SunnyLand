using  UnityEngine;
using UnityEngine.UI;

public class MethodFunctionQuestionABC : MonoBehaviour
{

    public  void AnswerPassQuesttionA(Canvas questionA, Canvas pause,
        Canvas panel,Text score, Text scoreTotal,AudioClip answerSound)
    {
        questionA.enabled = false;
        pause.enabled = true;
        panel.enabled = false;
        
    }

    public void AnswerFailQuestionA(AudioClip errorSound)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 40f;
        AudioSource.PlayClipAtPoint(errorSound, transform.position);
    }
}
