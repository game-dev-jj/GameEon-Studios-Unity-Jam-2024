using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] Button menuBtn;

    void Start()
    {
        menuBtn.onClick.AddListener(MenuButton);
    }

    void MenuButton()
    {
        AudioManager.Instance.PlaySFX("ClickSFX");
        SceneManager.LoadScene(0);
    }
}
