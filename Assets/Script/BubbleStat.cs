using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStat : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        Debug.Log("Sisa darah player: " + health);
        if (health <= 0)
        {
            Debug.Log("Bubble Dead");
        }
    }
}
