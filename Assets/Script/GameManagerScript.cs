using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private MovementController playerMovement;
    [SerializeField] private Weapon weaponPlayer;
    [SerializeField] private AudioClip gameOverAudioClip;

    public GameObject gameOverUI;
    public GameObject menuPaused;
    public GameObject gameFinishUI;
    public GameObject hud;
    public GameObject player;
    public GameObject bgm;
    public GameObject gameLoop;
    public string sceneName;
    public static bool isGamePaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
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
        isGamePaused = false;
        SceneManager.LoadScene(sceneName);
        hud.SetActive(true);
        menuPaused.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        StartCoroutine(TriggerGameOver());
    }
    public void GameOver1()
    {
        bgm.SetActive(false);
        isGamePaused = true;
        player.SetActive(false);
        Time.timeScale = 0f;
        gameLoop.SetActive(false);
        gameOverUI.SetActive(true);
        hud.SetActive(false);
        AudioManager.Instance.PlaySound(gameOverAudioClip);
    }

    public void GameFinish()
    {
        StartCoroutine(TriggerFinish());
    }
    public void Paused()
    {
        menuPaused.SetActive(true);
        Time.timeScale = 0f;

        // if (playerMovement != null)
        //     playerMovement.enabled = false;

        // if (weaponPlayer != null)
        //     weaponPlayer.enabled = false;

        isGamePaused = true;
    }

    public void Resume()
    {
        menuPaused.SetActive(false);
        Time.timeScale = 1f;

        // if (playerMovement != null)
        //     playerMovement.enabled = true;

        // if (weaponPlayer != null)
        //     weaponPlayer.enabled = true;

        isGamePaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator TriggerFinish()
    {
        bgm.SetActive(false);
        yield return new WaitForSeconds(3f);
        isGamePaused = true;
        player.SetActive(false);
        Time.timeScale = 0f;
        gameLoop.SetActive(false);
        hud.SetActive(false);
        gameFinishUI.SetActive(true);
    }

    private IEnumerator TriggerGameOver()
    {
        bgm.SetActive(false);
        yield return new WaitForSeconds(2f);
        isGamePaused = true;
        player.SetActive(false);
        Time.timeScale = 0f;
        gameLoop.SetActive(false);
        gameOverUI.SetActive(true);
        hud.SetActive(false);
    }

}
