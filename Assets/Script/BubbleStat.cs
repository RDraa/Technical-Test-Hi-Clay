using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStat : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthUI1;
    public GameObject healthUI2;
    public GameObject healthUI3;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        Debug.Log("Sisa darah player: " + health);
        if (health == 2)
        {
            healthUI1.SetActive(false);
        }
        if (health == 1)
        {
            healthUI2.SetActive(false);
        }
        if (health <= 0)
        {
            Debug.Log("Bubble Dead");
            healthUI3.SetActive(false);
        }
    }
}
