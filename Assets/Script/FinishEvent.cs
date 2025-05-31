using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEvent : MonoBehaviour
{
    [SerializeField] private AudioClip gameFinishAudioClip;
    [SerializeField] private GameManagerScript gameFinish;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finish");
            Debug.Log("Audio: " + gameFinishAudioClip);
            AudioManager.Instance.PlaySound(gameFinishAudioClip);
            gameFinish.GameFinish();
            // StartCoroutine(TriggerFinish());
        }
    }
    
    
    
}
