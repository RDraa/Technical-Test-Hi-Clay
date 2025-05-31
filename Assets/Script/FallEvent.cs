using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEvent : MonoBehaviour
{
    [SerializeField]private GameManagerScript gameOver;
    [SerializeField] private AudioClip gameOverAudioClip;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(gameOverAudioClip);
            gameOver.GameOver();
            // StartCoroutine(TriggerGameOverSequence());
        }
    }

    // private IEnumerator TriggerGameOverSequence()
    // {
        
    //     yield return new WaitForSeconds(2f);
        
    // }
}
