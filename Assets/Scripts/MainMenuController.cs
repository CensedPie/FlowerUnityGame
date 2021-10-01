using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton, quitButton;
    void Awake()
    {
        startButton.onClick.AddListener(StartClicked);
        quitButton.onClick.AddListener(QuitClicked);
    }
    public void StartClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitClicked()
    {
        Application.Quit();
    }
}
