using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private TextMeshProUGUI timeFinish;
    private string finalTime;
    [SerializeField] private Timer timer;

    void Start()
    {

    }

    void Update()
    {
        remainingTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        GameFinish();
    }

    public void OnGameFinish()
    {
        finalTime = timerText.text;
        timeFinish.text = finalTime;
    }
    

    void GameFinish()
    {
        timer.OnGameFinish();
    }

}
