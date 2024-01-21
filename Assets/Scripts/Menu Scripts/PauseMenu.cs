using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] Button resumeBtn;
    [SerializeField] Button restartBtn;
    [SerializeField] Button menuBtn;

    void Start()
    {
        pauseMenuPanel.SetActive(false);

        resumeBtn.onClick.AddListener(ResumeButton);
        restartBtn.onClick.AddListener(RestartButton);
        menuBtn.onClick.AddListener(MenuButton);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartButton();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuPanel.activeInHierarchy)
            {
                PlayClickSound();
                pauseMenuPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                ResumeButton();
            }
        }
    }

    void ResumeButton()
    {
        PlayClickSound();
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void RestartButton()
    {
        Time.timeScale = 1.0f;
        PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MenuButton()
    {
        Time.timeScale = 1.0f;
        PlayClickSound();
        SceneManager.LoadScene(0);
    }

    void PlayClickSound()
    {
        AudioManager.Instance.PlaySFX("ClickSFX");
    }
}
