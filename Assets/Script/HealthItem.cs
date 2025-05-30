using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private int itemRegen = 1;
    // public BubbleStat bubbleStat;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            BubbleStat bubbleStat = other.GetComponent<BubbleStat>();
            if (bubbleStat.health < 3)
            {
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
