using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject menuPaused;
    public GameObject gameFinishUI;
    public GameObject hud;
    public GameObject player;
    public GameObject bgm;
    public GameObject bgmGameFinish;
    public GameObject bgmGameOver;
    public string sceneName;
    public static bool isGamePaused = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
                Debug.Log("Resume Game");
            }
            else
            {
                Paused();
                Debug.Log("Paused Menu");
            }
        }
    }

    public void GameStart()
    {
        player.SetActive(true);
        bgm.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        hud.SetActive(true);
        menuPaused.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        hud.SetActive(false);
        bgm.SetActive(false);
        hud.SetActive(false);
        bgmGameOver.SetActive(true);
    }

    public void GameFinish()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
        hud.SetActive(false);
        bgm.SetActive(false);
        bgmGameFinish.SetActive(true);
        gameFinishUI.SetActive(true);
    }

    public void Paused()
    {
        menuPaused.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        menuPaused.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
