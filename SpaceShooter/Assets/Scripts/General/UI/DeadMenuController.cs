﻿using UnityEngine;
using UnityEngine.UI;

public class DeadMenuController : MonoBehaviour
{
    //Public
    public GameObject m_ButtonSound;

    //Private
    private Button[] m_Buttons;
    private Text[] m_Texts;
    private Text m_ScoreText;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_Buttons = GetComponentsInChildren<Button>();
        foreach (Button button in m_Buttons)
        {
            button.onClick.AddListener(() => RunOption(button.name));
        }

        m_Texts = GetComponentsInChildren<Text>();
        foreach (Text text in m_Texts)
        {
            if(text.name == "Score")
            {
                m_ScoreText = text;
                UpdateScore();
                break;
            }
        }
        GameFlowManager.Instance.m_ScoreChangedEvent.AddListener(UpdateScore);
        m_AudioSource = m_ButtonSound.GetComponent<AudioSource>();
    }

    private void UpdateScore()
    {
        m_ScoreText.text = "Score: " + GameFlowManager.Instance.GetScore();
    }


    public void RunOption(string option)
    {
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        switch (option)
        {
            case "PlayAgain":
                GameFlowManager.Instance.StartGame();
                break;

            case "Return":
                GameFlowManager.Instance.ReturnToMainMenuFromDeadMenu();
            break;

            default:
                Debug.LogError("Button name must match option name. Check DeadMenuController script.");
            break;
        }
    }
}
