using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackGroundImageCanvasGroup;
    bool m_IsPlayerAtExit;
    float m_Timer;
    public float displayImageDuration = 1f;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    bool m_IsPlayerCaught;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    bool m_HasAudioPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackGroundImageCanvasGroup, false, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (doRestart)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Application.Quit();
        }
    }
}
