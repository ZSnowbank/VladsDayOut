using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_ui;
    [SerializeField] GameObject m_pauseScreen;

    void Start()
    {
        if (m_pauseScreen) m_pauseScreen.SetActive(false);
    }

    public void LoadLevel(string level)
    {
        print("Im being called");
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if(m_pauseScreen) m_pauseScreen.SetActive(true);
        if(m_ui) m_ui.SetActive(false);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        if(m_pauseScreen) m_pauseScreen.SetActive(false);
        if(m_ui) m_ui.SetActive(true);
    }
}
