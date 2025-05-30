using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private AudioClip regenAudioClip;
    private int itemRegen = 1;
    // public BubbleStat bubbleStat;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            AudioManager.Instance.PlaySound(regenAudioClip);
            BubbleStat bubbleStat = other.GetComponent<BubbleStat>();
            if (bubbleStat.health < 3)
            {
                if (bubbleStat.health == 2)
                {
                    bubbleStat.healthUI1.SetActive(true);
                }
                if (bubbleStat.health == 1)
                {
                    bubbleStat.healthUI2.SetActive(true);
                }
                bubbleStat.health += itemRegen;
                Destroy(gameObject);
                Debug.Log("Health Bubble: " + bubbleStat.health);
            }
            else
            {
                Debug.Log("Health penuh!");
            }
        }
    }
}
