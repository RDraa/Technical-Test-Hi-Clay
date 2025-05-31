using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCard : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public GameObject canvasToDelete;
    public static bool tutorialShown = false;

    private void Start()
    {
        if (tutorialShown)
        {
            Destroy(canvasToDelete);
            Time.timeScale = 1f;
            GameManagerScript.isGamePaused = false;
            gameManagerScript.isTutorialActive = false;
        }
        else
        {
            Time.timeScale = 0f;
            GameManagerScript.isGamePaused = true;
            gameManagerScript.isTutorialActive = true;
        }
    }

    public void TutoCardDeleted()
    {
        tutorialShown = true;

        Destroy(canvasToDelete);
        GameManagerScript.isGamePaused = false;
        gameManagerScript.hud.SetActive(true);
        gameManagerScript.isTutorialActive = false;
        Time.timeScale = 1f;
    }
}
