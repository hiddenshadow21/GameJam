using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    private GameObject deathPanel;
    private bool pauseGame;

    private void Start()
    {
        if (instance == null)
            instance = this;
        deathPanel.SetActive(false);
    }

    public void GameOver()
    {
        ToogleTime();
        deathPanel.SetActive(true);
    }

    private void ToogleTime()
    {
        pauseGame = !pauseGame;
        if (pauseGame == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
