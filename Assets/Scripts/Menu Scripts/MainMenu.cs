using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [Space(10)]
    [SerializeField] Button playBtn;
    [SerializeField] GameObject difficultyPanel;
    [SerializeField] Button normalModeBtn;
    [SerializeField] Button proModeBtn;
    [SerializeField] Button difficultyBackBtn;
    [Space(10)]
    [SerializeField] Button controlsBtn;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] Button controlsBackBtn;
    [Space(10)]
    [SerializeField] Button quitBtn;
    [SerializeField] GameObject quitConfirmPanel;
    [SerializeField] Button quitYesBtn;
    [SerializeField] Button quitNoBtn;

    void Start()
    {
        menuPanel.SetActive(true);

        playBtn.onClick.AddListener(PlayButton);
        normalModeBtn.onClick.AddListener(NormalModeButton);
        proModeBtn.onClick.AddListener(ProModeButton);
        difficultyBackBtn.onClick.AddListener(DifficultyBackButton);

        controlsBtn.onClick.AddListener(ControlsButton);
        controlsBackBtn.onClick.AddListener(ControlsbackButton);

        quitBtn.onClick.AddListener(QuitButton);
        quitYesBtn.onClick.AddListener(QuitYesButton);
        quitNoBtn.onClick.AddListener(QuitNoButton);

        difficultyPanel.SetActive(false);
        controlsPanel.SetActive(false);
        quitConfirmPanel.SetActive(false);
    }

    void PlayButton()
    {
        PlayClickSound();
        difficultyPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    void NormalModeButton()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
    }
    void ProModeButton()
    {
        PlayClickSound();
        SceneManager.LoadScene(2);
    }
    void DifficultyBackButton()
    {
        PlayClickSound();
        menuPanel.SetActive(true);
        difficultyPanel.SetActive(false);
    }

    void ControlsButton()
    {
        PlayClickSound();
        controlsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    void ControlsbackButton()
    {
        PlayClickSound();
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    void QuitButton()
    {
        PlayClickSound();
        quitConfirmPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    void QuitYesButton()
    {
        PlayClickSound();
        //Screen.fullScreen = !Screen.fullScreen;
        Application.Quit();
    }
    void QuitNoButton()
    {
        PlayClickSound();
        menuPanel.SetActive(true);
        quitConfirmPanel.SetActive(false);
    }

    void PlayClickSound()
    {
        AudioManager.Instance.PlaySFX("ClickSFX");
    }
}
